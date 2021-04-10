using NewsApp.Core.Helpers;
using NewsApp.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Core
{
    public class Services : IServices
    {
        public async Task<IRestResponse> GetNews(IRequestModel requestModel)
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

            request.AddQueryParameter("categories", requestModel.Categories);
            request.AddQueryParameter("search", requestModel.Search);
            request.AddQueryParameter("limit", requestModel.Limit.ToString());

            IRestResponse response = await client.ExecuteAsync(request);
            Debug.WriteLine(response.Content);
            return response;
        }
    }
}
