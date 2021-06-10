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
        Users,
        Preferences,
        Favorites,
        History
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
            FirebaseDB firebaseDB = new FirebaseDB($"{BaseURL}");
            FirebaseDB firebaseDBTeams = firebaseDB.Node(userName);
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            Debug.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Debug.WriteLine(getResponse.JSONContent);
            return JsonReader<FirebaseGetUserResponse>.JsonDeserialize(getResponse.JSONContent);
        }
        public List<string> GetUserInfo(string userName, DbRequestType dbRequestType)
        {
            FirebaseDB firebaseDB = new FirebaseDB($"{BaseURL}");
            FirebaseDB firebaseDBTeams = firebaseDB.Node($"{userName}/{dbRequestType}");
            FirebaseResponse getResponse = firebaseDBTeams.Get();
            Debug.WriteLine(getResponse.Success);
            if (getResponse.Success)
                Debug.WriteLine(getResponse.JSONContent);
            return JsonReader<List<string>>.JsonDeserialize(getResponse.JSONContent);
        }
        public bool PutUserData<T>(T DataToAdd,DbRequestType dbRequestType, string UserName)
        {
            FirebaseDB firebaseDB = null;
            switch (dbRequestType)
            {
                case DbRequestType.Users:
                    firebaseDB = new FirebaseDB($"{BaseURL}");
                    break;
                default:
                    firebaseDB = new FirebaseDB($"{BaseURL}/{dbRequestType}");
                    break;
            }
            
            FirebaseDB firebaseDBTeams = firebaseDB.Node(UserName);
            var json = JsonConvert.SerializeObject(DataToAdd);
            FirebaseResponse getResponse = firebaseDBTeams.Put(json);
            if (getResponse.Success)
                return true;
            else
            return false;
        }
    }
}
