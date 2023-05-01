pipeline{
    agent any
    stages {
        stage('Setup Python Virtual ENV') {
            steps {
                sh  '''
                cd fdc
                chmod +x envsetup.sh
                ./envsetup.sh
                ''' 
            }
        }

        stage('Setup env Activate') {
            steps {
                sh '''
                cd /var/lib/jenkins/workspace/A201_FDC_Server/fdc
                chmod +x venvActivate.sh
                ./venvActivate.sh
                '''
            }
        }
    }
}