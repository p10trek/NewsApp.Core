using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Core.ResponseModel
{
    class FirebaseGetUsersResponse : IDisposable
    {
        public List<FirebaseGetUserResponse> Users { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (var user in Users)
                {
                    user.credentials = new FirebaseGetUserResponse.Credentials
                    {
                        password = String.Empty,
                        token = String.Empty,
                        user = String.Empty
                    };
                    user.favorites = new string[] { string.Empty };
                    user.history = new string[] { string.Empty };
                    user.preferences = new FirebaseGetUserResponse.Preferences
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
}
