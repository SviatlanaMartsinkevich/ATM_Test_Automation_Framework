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
	
	environment {
		BROWSER_VAL = "${params.BROWSER}" 
	}

	
    stages{
	
		stage('Build') {
			steps{
			bat 'C:\\nuget\\nuget.exe restore ATM_Test_Automation_Framework.sln'
             bat 'MSBuild.exe ATM_Test_Automation_Framework.sln'
			}
		}
		
        stage('API Tests') {
            steps {
               // Use VSTest.Console.exe to run API 
				catchError(buildResult: 'SUCCESS', stageResult: 'FAILURE'){
                bat 'dotnet vstest Tests/bin/Debug/Tests.dll --logger:trx --TestCaseFilter:TestCategory=API'
				}
			} 
			post {
					always{
					// Archive the test results and screenshots
					   archiveArtifacts 'TestResults/**.trx'
					  
					}
				}	
		}
		
		stage('Prepare Config') {
					steps {
						sh 'envsubst < app.config.template > App.config'
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
					catchError(buildResult: 'SUCCESS', stageResult: 'FAILURE'){
					bat "dotnet vstest Tests/bin/Debug/Tests.dll --logger:trx --TestCaseFilter:TestCategory=UI"
                  }
			 }
				
            post {
					always{
					// Archive the test results and screenshots
					   archiveArtifacts 'TestResults/**.trx'
					   archiveArtifacts 'Tests/bin/Debug/**.Jpeg'
					}
				}		 
		}
    }
	
	 post {
		always{
        // Archive all artifacts at the end of the pipeline run
        archiveArtifacts 'TestResults/**.trx'
        archiveArtifacts 'Tests/bin/Debug/**.Jpeg'
		}
    }
}
