using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.ResponseModel
{
    public class FirebaseGetUserResponse : IDisposable
    {
        public Credentials credentials { get; set; }
        public string[] favorites { get; set; }
        public string[] history { get; set; }
        public Preferences preferences { get; set; }

        public class Credentials
        {
            public string password { get; set; }
            public string token { get; set; }
            public string user { get; set; }
        }

        public class Preferences
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
                this.credentials = new FirebaseGetUserResponse.Credentials
                {
                    password = String.Empty,
                    token = String.Empty,
                    user = String.Empty
                };
                this.favorites = new string[] { string.Empty };
                this.history = new string[] { string.Empty };
                this.preferences = new FirebaseGetUserResponse.Preferences
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
