pipeline {
    agent any

    options {
        // Enable build retention to keep build history
        buildDiscarder(logRotator(numToKeepStr: '10'))
    }

    triggers {
        // Run on pull request to branch
        pullRequest {
            branchTargetBranch = 'master'
            triggerPhrase = 'run tests'
        }
        // Run on schedule (every day at 8am)
        cron('0 8 * * *')
        // Run by manual start
    }
    
    parameters {
        // Parameter to select browser for UI tests
        choice(
            name: 'BROWSER',
            choices: ['Chrome', 'Firefox', 'Safari'],
            description: 'Select browser to run UI tests against'
        )
    }

    stages {
        stage('API Tests') {
            steps {
                // Use MSBuild to build the solution
                bat "dotnet build ATM_Test_Automation_Framework.sln --configuration Release"
                // Use VSTest.Console.exe to run API tests
                bat "dotnet vstest Tests/bin/Release/Tests.dll --logger:trx --TestCaseFilter:TestCategory=API"
            }
            post {
                // Archive the test results
                step([$class: 'NUnitPublisher', testResultsPattern: 'Tests/bin/Release/*.trx'])
            }
        }
        stage('UI Tests') {
            when {
                // Run UI tests only if API tests pass
                allOf {
                    not {
                        failed()
                    }
                    expression {
                        params.BROWSER != null
                    }
                }
            }
            steps {
                // Use VSTest.Console.exe to run UI tests with selected browser
                bat "dotnet vstest Tests/bin/Release/UITests.dll --logger:trx --TestCaseFilter:TestCategory=UI"
            }
            post {
                // Archive the test results and screenshots
                step([$class: 'NUnitPublisher', testResultsPattern: 'Tests/bin/Release/*.trx'])
                archiveArtifacts 'Tests/bin/Release/screenshots/*.png'
            }
        }
    }
}
