using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.ResponseModel
{
    public class FirebaseGetUserResponse : IDisposable
    {
        public Credentials_ Credentials { get; set; }
        public string[] Favorites { get; set; }
        public string[] History { get; set; }
        public Preferences_ Preferences { get; set; }

        public class Credentials_
        {
            public string password { get; set; }
            public string token { get; set; }
            public string login { get; set; }
        }

        public class Preferences_
        {
            public string categories { get; set; }
            public string language { get; set; }
            public int limit { get; set; }
            public DateTime published_after { get; set; }
            public DateTime published_before { get; set; }
            public DateTime published_on { get; set; }
            public string search { get; set; }
            public int timeout { get; set; }
            public string url { get; set; }
            public string domain { get; set; }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Credentials = new FirebaseGetUserResponse.Credentials_
                {
                    password = String.Empty,
                    token = String.Empty,
                    login = String.Empty
                };
                this.Favorites = new string[] { string.Empty };
                this.History = new string[] { string.Empty };
                this.Preferences = new FirebaseGetUserResponse.Preferences_
                {
                    published_after = new DateTime(),
                    categories = String.Empty,
                    language = String.Empty,
                    limit = 0,
                    published_before = new DateTime(),
                    published_on = new DateTime(),
                    search = String.Empty,
                    timeout = 0,
                    url = String.Empty
                };
            }
        }
    }
}
