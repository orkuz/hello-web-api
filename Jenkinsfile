pipeline {
    agent any
    environment {
		DOCKERHUB_CREDENTIALS=credentials('orkuz-dockerhub')
	}
    
    stages {
        stage('Prepare for build') {
            steps {
                echo 'Preparing environment...'
            }
        } 
        stage('Test') {
            steps {
                echo 'Testing the application...'
                sh './mvnw test -DskipTests'
            }
        }
        stage('Build C# app') {
            steps {
                echo 'Building application artifacts...'
            }
        }
        stage('Build and push docker image') {
            steps {
                echo 'Logging in to DockerHub...'
                sh 'echo $DOCKERHUB_CREDENTIALS_PSW | docker login -u $DOCKERHUB_CREDENTIALS_USR --password-stdin'
                script {
                    echo "Building image orkuztech/hello-web-api"
                    def appImage = docker.build("orkuztech/hello-web-api")
                    appImage.push("${currentBuild.number}")
                    appImage.push("latest")
                }
            }
        }
    }
}
