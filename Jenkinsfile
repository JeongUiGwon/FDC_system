pipeline{
    agent any
    stages {
        stage('Setup Python Virtual ENV') 
        {
            sh  '''
            cd fdc
            chmod +x envsetup.sh
            ./envsetup.sh
            '''
        }
    }
}