using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Core.Interfaces
{
    public interface IServices
    {
        Task<IRestResponse> GetNews(IRequestModel requestModel);
    }
}
