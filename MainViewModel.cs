using MvvmCross.ViewModels;
using NewsApp.Core.Interfaces;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Core
{
    class MainViewModel : MvxViewModel
    {
        private readonly IServices services;
        public MainViewModel(IServices services)
        {
            this.services = services;
        }
        public async Task<IRestResponse> GetNews(IRequestModel requestModel)
        {
            return await services.GetNews(requestModel);
        }
    }
}
