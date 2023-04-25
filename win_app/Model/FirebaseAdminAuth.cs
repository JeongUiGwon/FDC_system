using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
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

        public async Task<ObservableCollection<UsersModel>> GetUserList()
        {
            // User 정보 리스트 조회
            ObservableCollection<UsersModel> users = new ObservableCollection<UsersModel>();
            var enumerator = FirebaseAuth.DefaultInstance.ListUsersAsync(null).GetAsyncEnumerator();
            while (await enumerator.MoveNextAsync())
            {
                ExportedUserRecord user = enumerator.Current;
                users.Add(new UsersModel(user.Email, user.Uid, user.DisplayName, user.CustomClaims["Authority"].ToString(), user.CustomClaims["PhoneNumber"].ToString()));
            }

            return users;
        }
    }
}
