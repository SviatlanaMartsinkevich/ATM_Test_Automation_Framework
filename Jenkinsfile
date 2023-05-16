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
		stage('NuGet Package Restore') {
            steps {
                // Restore NuGet packages
                bat 'C:\\nuget\\nuget.exe restore ATM_Test_Automation_Framework.sln'
            }
        }
	
		stage('Build') {
			steps{
			// bat "C:/nuget/nuget.exe restore ATM_Test_Automation_Framework.sln"
             bat 'MSBuild.exe ATM_Test_Automation_Framework.sln'
			}
		}
		
       // stage('API Tests') {
        //    steps {
         //       // Use VSTest.Console.exe to run API 
		//		 catchError(buildResult: 'SUCCESS', stageResult: 'FAILURE'){
        //        bat 'dotnet vstest Tests/bin/Debug/Tests.dll --logger:trx --TestCaseFilter:TestCategory=API'
		//			}
		//		}
           // post {
			//	always{
             //   // Archive the test results
			//		step([$class: 'NUnitPublisher', testResultsPattern: 'Tests/bin/Release/*.trx'])
			//		}
			//	}
		//	}
			
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
					bat "dotnet vstest Tests/bin/Debug/UITests.dll --logger:trx --TestCaseFilter:TestCategory=UI"
                  }
				
           // post {
			//		always{
			//		// Archive the test results and screenshots
			//		step([$class: 'NUnitPublisher', testResultsPattern: 'Tests/bin/Release/*.trx'])
			//		archiveArtifacts 'Tests/bin/Release/screenshots/*.png'
			//			}
			//	}		 
		}
    }
}
