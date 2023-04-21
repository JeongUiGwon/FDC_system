using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;

namespace SOM.Model
{
    public class FirebaseAdminAuth
    {
        public static FirebaseApp firebase = FirebaseApp.Create(
            new AppOptions()
            {
                Credential = GoogleCredential.FromFile("./firebase-adminsdk.json"),
            });

        public FirebaseAuth auth = FirebaseAuth.DefaultInstance;
    }
}
