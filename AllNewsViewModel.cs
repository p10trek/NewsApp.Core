using MvvmCross.Commands;
using MvvmCross.ViewModels;
using NewsApp.Core.Interfaces;
using NewsApp.Core.ResponseModel;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace NewsApp.Core
{
    public class AllNewsViewModel : MvxViewModel
    {
        private readonly IServices services;

        private string _response;
        public string Response
        {
            get => _response;
            set
            {
                _response = value;
                RaisePropertyChanged(() => Response);
            }
        }
        
        private string _search;
        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                RaisePropertyChanged(() => Search);
            }
        }
        private bool _general;
        public bool General
        {
            get => _general;
            set
            {
                _general = value;
                RaisePropertyChanged(() => General);
            }
        }
        private bool _science;
        public bool Science
        {
            get => _science;
            set
            {
                _science = value;
                RaisePropertyChanged(() => Science);
            }
        }
        private bool _sports;
        public bool Sports
        {
            get => _sports;
            set
            {
                _sports = value;
                RaisePropertyChanged(() => Sports);
            }
        }
        private bool _business;
        public bool Business
        {
            get => _business;
            set
            {
                _business = value;
                RaisePropertyChanged(() => Business);
            }
        }
        private bool _health;
        public bool Health
        {
            get => _health;
            set
            {
                _health = value;
                RaisePropertyChanged(() => Health);
            }
        }
        private bool _entertainment;
        public bool Entertainment
        {
            get => _entertainment;
            set
            {
                _entertainment = value;
                RaisePropertyChanged(() => Entertainment);
            }
        }
        private bool _tech;
        public bool Tech
        {
            get => _tech;
            set
            {
                _tech = value;
                RaisePropertyChanged(() => Tech);
            }
        }
        private bool _politics;
        public bool Politics
        {
            get => _politics;
            set
            {
                _politics = value;
                RaisePropertyChanged(() => Politics);
            }
        }
        private bool _food;
        public bool Food
        {
            get => _food;
            set
            {
                _food = value;
                RaisePropertyChanged(() => Food);
            }
        }
        private bool _travel;
        public bool Travel
        {
            get => _travel;
            set
            {
                _travel = value;
                RaisePropertyChanged(() => Travel);
            }
        }
        public IMvxCommand DoWorkCommand => new MvxCommand(DoWork, () => true);
        private void DoWork()
        {
            IRequestModel requestModel = new RequestModel();
            requestModel.Categories = String.Empty;
            if (General)
                requestModel.Categories += "general,";
            if (Science)
                requestModel.Categories += "science,";
            if (Sports)
                requestModel.Categories += "sports,";
            if (Business)
                requestModel.Categories += "business,";
            if (Health)
                requestModel.Categories += "health,";
            if (Entertainment)
                requestModel.Categories += "entertainment,";
            if (Tech)
                requestModel.Categories += "tech,";
            if (Politics)
                requestModel.Categories += "politics,";
            if (Food)
                requestModel.Categories += "food,";
            if (Travel)
                requestModel.Categories += "travel,";
            if(!String.IsNullOrEmpty(requestModel.Categories))
                requestModel.Categories =  requestModel.Categories
                                           .Remove(requestModel.Categories.Length - 1, 1);
            if (!String.IsNullOrEmpty(Search))
                requestModel.Search = Search;
            requestModel.Timeout = -1;
            requestModel.Limit = 5;
            requestModel.Token = "HgcpXI8z8J7yLHOCfRxpluxoGgUA7zYbGmq5PdAR";
            requestModel.Url = "https://api.thenewsapi.com/v1/news/all";
            var result = services.GetNews(requestModel);
            AllNews.Rootobject allNews =  JsonReader<AllNews.Rootobject>.JsonDeserialize(result.Content);
            Fill(allNews);






        }
        public IMvxAsyncCommand DoAsyncWorkCommand => new MvxAsyncCommand(DoAsyncWorkAsync, () => true);
        private Task DoAsyncWorkAsync()
        {
            // Async work logic here
            //var result =  services.GetNews(requestModel).Result();
            //return JsonReader<AllNews>.JsonDeserialize(result.Content);
            return Task.FromResult(true);
        }
        public override async Task Initialize()
        {
            await base.Initialize();
        }
        public AllNewsViewModel(IServices services)
        {
            this.services = services;

        }
        public async Task<AllNews.Rootobject> GetNews(IRequestModel requestModel)
        {
            var result = services.GetNews(requestModel);
            return JsonReader<AllNews.Rootobject>.JsonDeserialize(result.Content);
        }
        public ObservableCollection<AllNewsModel> NewsList { get; set; } = new ObservableCollection<AllNewsModel>();

        private Random rand = new Random();

        private void Fill(AllNews.Rootobject allNews)
        {
            foreach (var news in allNews.data)
            {
                NewsList.Add(new AllNewsModel
                {
                    Image = news.image_url,
                    Content = news.description,
                    Title = news.title
                });
            }
            
        }
    }
}
