pipeline {
  agent any
  stages {
    stage('Tests') {
      steps {
        dotnetBuild(workDirectory: 'Debug')
        dotnetTest(outputDirectory: 'Debug')
      }
    }

  }
}