using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Core.Interfaces
{
    public interface IServices
    {
        IRestResponse GetNews(IRequestModel requestModel, String userLogin = "");
        Task<IRestResponse> GetNewsAsync(IRequestModel requestModel, string userName = "");
        IRestResponse GetNews(string uri);
    }
}
