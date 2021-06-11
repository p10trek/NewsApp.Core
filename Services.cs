using NewsApp.Core.DataBase;
using NewsApp.Core.Helpers;
using NewsApp.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Core
{
    public class Services : IServices
    {
        public IRestResponse GetNews(IRequestModel requestModel, string userName = "")
        {
            string methodName = GenericFactory<RuntimeInfo>
                                .CreateInstance()
                                .GetMethodName();

            if (String.IsNullOrEmpty(requestModel.Url))
                throw new CustomException(ExceptionMessages.UrlIsEmpty, methodName);

            var client = new RestClient(requestModel.Url);
            client.Timeout = requestModel.Timeout;
            var request = new RestRequest(Method.GET);

            if (String.IsNullOrEmpty(requestModel.Token))
                throw new CustomException(ExceptionMessages.TokenIsEmpty, methodName);

            request.AddQueryParameter("api_token", requestModel.Token);
            if (!String.IsNullOrEmpty(requestModel.Categories))
                request.AddQueryParameter("categories", requestModel.Categories);
            if (!String.IsNullOrEmpty(requestModel.Search))
                request.AddQueryParameter("search", requestModel.Search);
                request.AddQueryParameter("limit", requestModel.Limit.ToString());
            if (!String.IsNullOrEmpty(requestModel.language))
                request.AddQueryParameter("language", requestModel.language);
            request.AddQueryParameter("published_after", requestModel.published_after.ToString("yyyy-MM-dd"));
            if (!String.IsNullOrEmpty(requestModel.domains))
                request.AddQueryParameter("domains", requestModel.domains);
            IRestResponse response = client.Execute(request);

            if (!String.IsNullOrEmpty(userName))
            {
                if (!String.IsNullOrEmpty(response.ResponseUri.OriginalString))
                {
                    var dll = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/Users/{node}");
                    List<string> fav = new List<string>();
                    
                    var data = dll.GetUserInfo(userName, DbRequestType.History);
                    if (data != null)
                        fav.AddRange(data);

                    if (!fav.Contains(response.ResponseUri.OriginalString))
                    {
                        fav.Add(response.ResponseUri.OriginalString);
                        dll.PutUserData(fav, DbRequestType.History, userName);
                    }
                }
            }
            Debug.WriteLine(response.Content);
            return response;
        }
        public IRestResponse GetNews(string uri)
        {
            var client = new RestClient(uri);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            return client.Execute(request);

        }

    }
}
