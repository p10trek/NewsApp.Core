using NewsApp.Core.ResponseModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NewsApp.Core.DataBase
{
    
    public enum DbRequestType
    {
        User,
        Users
    }
    public class DLL
    {
        public string BaseURL { get; set; }
        public DLL() {}
        public DLL(string baseURL)
        {
            this.BaseURL = baseURL;
        }
   
        public FirebaseGetUserResponse GetUserData(DbRequestType dbRequestType, string userName="")
        {
            FirebaseDB firebaseDB = new FirebaseDB($"{BaseURL}{dbRequestType}");
            FirebaseDB firebaseDBTeams = firebaseDB.Node(userName);
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            Debug.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Debug.WriteLine(getResponse.JSONContent);
            return JsonReader<FirebaseGetUserResponse>.JsonDeserialize(getResponse.JSONContent);
        }
        public bool PutUserData(FirebaseGetUserResponse userToAdd,DbRequestType dbRequestType, string UserName)
        {
            FirebaseDB firebaseDB = new FirebaseDB($"{BaseURL}{dbRequestType}");
            FirebaseDB firebaseDBTeams = firebaseDB.Node(UserName);
            var json = JsonConvert.SerializeObject(userToAdd);
            FirebaseResponse getResponse = firebaseDBTeams.Put(json);
            if (getResponse.Success)
                return true;
            else
            return false;
        }
    }
}
