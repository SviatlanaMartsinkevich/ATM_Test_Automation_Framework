pipeline {
    agent any

    options {
        // Enable build retention to keep build history
        buildDiscarder(logRotator(numToKeepStr: '10'))
    }

    triggers {
        // Run on pull request to branch
       // pullRequest :
            //branchTargetBranch = 'master'
            
        // Run on schedule (every day at 8am)
        cron('0 8 * * *')
        // Run by manual start
    }
    
    parameters {
        // Parameter to select browser for UI tests
        string(
            name: 'BROWSER',
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
				always{
                // Archive the test results
					step([$class: 'NUnitPublisher', testResultsPattern: 'Tests/bin/Release/*.trx'])
					}
				}
			}
			
        stage('UI Tests') {
            when {
                // Run UI tests after API tests
                expression {
                    if(params.BROWSER == null){
					  params.BROWSER == "CHROME"
					} else{
                      params.BROWSER == "${BROWSER}"
					 }
                    }
				   }
				
            steps {
					// Use VSTest.Console.exe to run UI tests with selected browser
					bat "dotnet vstest Tests/bin/Release/UITests.dll --logger:trx --TestCaseFilter:TestCategory=UI"
                  }
            post {
					always{
					// Archive the test results and screenshots
					step([$class: 'NUnitPublisher', testResultsPattern: 'Tests/bin/Release/*.trx'])
					archiveArtifacts 'Tests/bin/Release/screenshots/*.png'
						}
				}		 
		}
    }
}
