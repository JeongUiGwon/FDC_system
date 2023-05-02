pipeline{
    agent any
    stages {
        stage('Docker build') {
            steps {
                sh  '''
                cd /var/lib/jenkins/workspace/A201_FDC_Server/fdc
                sudo docker build -t jeonguigwon/a201_fdc .
                ''' 
            }
        }

        stage('Docker Push') {
            steps {
                sh '''
                sudo docker push jeonguigwon/a201_fdc
                '''
            }
        }

        stage('Docker Initial') {
            steps {
                sh '''
                sudo docker stop a201_fdc
                sudo docker rm a201_fdc
                '''
            }
        }

        stage('Docker Run') {
            steps {
                sh '''
                sudo docker run --name a201_fdc -d -p 8000:8000 jeonguigwon/a201_fdc
                '''
            }
        }
    }
}