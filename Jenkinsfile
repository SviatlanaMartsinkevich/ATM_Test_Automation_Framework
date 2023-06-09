pipeline {
    agent any

    options {
          buildDiscarder(logRotator(numToKeepStr: '10'))
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

    triggers {

      GenericTrigger(
            token: env.TOKEN,
            genericVariables: [
                [key: 'action', value: '$.action'],
                [key: 'pullRequestId', value: '$.pull_request.id'],
                [key: 'branch', value: '$.pull_request.head.ref']
            ],
            causeString: 'Pull Request Event',
            printContributedVariables: true
			)
			
        cron('0 8 * * *')
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
				catchError(buildResult: 'SUCCESS', stageResult: 'FAILURE'){
                bat 'dotnet vstest Tests/bin/Debug/Tests.dll --logger:trx --TestCaseFilter:TestCategory=API'
				}
			} 
			post {
					always{
					   archiveArtifacts 'TestResults/**.trx'
					 }
				}	
		}
			
        stage('UI Tests') {
            when { 
                expression {
                    if(params.BROWSER == null){
					  params.BROWSER == "CHROME"
					} else{
                      params.BROWSER == "${BROWSER}"
					 }
                    }
				 }
				
				
            steps {
					catchError(buildResult: 'SUCCESS', stageResult: 'FAILURE'){
					bat "dotnet vstest Tests/bin/Debug/Tests.dll --logger:trx --TestCaseFilter:TestCategory=UI"
                  }
			 }
				
            post {
					always{
					   archiveArtifacts 'TestResults/**.trx'
					   archiveArtifacts 'Tests/bin/Debug/**.Jpeg'
					}
				}		 
		}
    }
	
	 post {
		always{
        archiveArtifacts 'TestResults/**.trx'
        archiveArtifacts 'Tests/bin/Debug/**.Jpeg'
		}
    }
}