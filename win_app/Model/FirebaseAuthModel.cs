using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOM.Model
{
    public class FirebaseAuthModel
    {
        private static FirebaseAuthConfig config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyDBRBUniwIniSz860bB1jlObgeH-M2Re9c",
            AuthDomain = "ssafy-a201.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
            {
                // Add and configure individual providers
                new GoogleProvider().AddScopes("email"),
                 new EmailProvider()
                // ...
            },
            // WPF:
            UserRepository = new FileUserRepository("FirebaseSample") // persist data into %AppData%\FirebaseSample
        };

        public FirebaseAuthClient client = new FirebaseAuthClient(config);
    }
}
