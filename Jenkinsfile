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
                chmod venvActivate.sh
                ./venvActibate.sh
                '''
            }
        }
    }
}