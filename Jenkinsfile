pipeline{
    agent any
    stages {
        stage('Docker build') {
            steps {
                sh  '''
                cd /var/lib/jenkins/workspace/A201_FDC_Server/fdc
                docker login
                docker build -t jeonguigwon/a201_fdc .
                ''' 
            }
        }

        stage('Docker Push') {
            steps {
                sh '''
                docker push jeonguigwon/a201_fdc
                '''
            }
        }

        stage('Docker Initial') {
            steps {
                sh '''
                docker stop a201_fdc
                docker rm a201_fdc
                '''
            }
        }

        stage('Docker Run') {
            steps {
                sh '''
                docker run --name a201_fdc -p -d 8000:8000 jeonguigwon/a201_fdc
                '''
            }
        }
    }
}