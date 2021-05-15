﻿using BCrypt.Net;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using NewsApp.Core.Interfaces;
using NewsApp.Core.ResponseModel;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Windows;
namespace NewsApp.Core
{
    public class AllNewsViewModel : MvxViewModel
    {
        private readonly IServices services;
        public AllNewsViewModel(IServices services)
        {
            this.services = services;
            ResultPanelVisibility = false;
            LoginPanelVisibility = true;


        }

        #region PROPERTIES
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
        private string _login;
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                RaisePropertyChanged(() => Login);
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        private string _token;
        public string Token
        {
            get => _token;
            set
            {
                _token = value;
                RaisePropertyChanged(() => Token);
            }
        }
        private string _domains;
        public string Domains
        {
            get => _domains;
            set
            {
                _domains = value;
                RaisePropertyChanged(() => Domains);
            }
        }
        private string _language;
        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                RaisePropertyChanged(() => Language);
            }
        }
        private DateTime _dateFrom;
        public DateTime DateFrom
        {
            get => _dateFrom;
            set
            {
                _dateFrom = value;
                RaisePropertyChanged(() => DateFrom);
            }
        }
        //private Visibility _loginPanelVisibility;
        public bool LoginPanelVisibility
        {
            //get => _loginPanelVisibility;
            set
            {
                //_loginPanelVisibility = value;
                //RaisePropertyChanged(() => LoginPanelVisibility);
            }
        }
        private bool _resultPanelVisibility;
        public bool ResultPanelVisibility
        {
            get => _resultPanelVisibility;
            set
            {
                _resultPanelVisibility = value;
                RaisePropertyChanged(() => ResultPanelVisibility);
            }
        }

        public IMvxCommand DoWorkCommand => new MvxCommand(DoWork, () => true);
        public IMvxCommand SignInCommand => new MvxCommand(SignIn, () => true);
        #endregion

        private void DoWork()
        {
            IRequestModel requestModel = new RequestModel();
            requestModel.Categories = AddCategories();
            if (!String.IsNullOrEmpty(Domains))
            requestModel.domains =  Domains;
            if (!String.IsNullOrEmpty(Language))
            requestModel.language = Language;
            requestModel.published_after = DateFrom;
            if (!String.IsNullOrEmpty(Search))
                requestModel.Search = Search;
            requestModel.Timeout = -1;
            requestModel.Limit = 5;
            //todo: create cofig file and read token from it
            requestModel.Token = "HgcpXI8z8J7yLHOCfRxpluxoGgUA7zYbGmq5PdAR";
            requestModel.Url = "https://api.thenewsapi.com/v1/news/all";
            var result = services.GetNews(requestModel);
            AllNews.Rootobject allNews =  JsonReader<AllNews.Rootobject>.JsonDeserialize(result.Content);
            Fill(allNews);
            ResultPanelVisibility = true;
        }
        private void SignIn()
        {
            string login = Login;
            if (File.Exists("Config.json"))
            {
                List<ConfigModel> configObject = JsonConvert.DeserializeObject<List<ConfigModel>>(File.ReadAllText("Config.json"));
                if(configObject.Where(row=>row.Login == this.Login).Count()>0)
                {
                    if(BCrypt.Net.BCrypt.Verify(this.Password, configObject.Where(row => row.Login == this.Login).FirstOrDefault().Password))
                    {
                        Debug.WriteLine("Przypisanie wartości do filtrow");    
                    }
                    else
                    {
                        Debug.WriteLine("Obsluga braku hasla");
                    }
                }
                else
                {
                    //todo: obsluzyc nullowa zawartosc
                    Debug.WriteLine("Utworzenie użytkownika");
                    configObject.Add(new ConfigModel
                    {
                        Login = this.Login,
                        Password = BCrypt.Net.BCrypt.HashPassword(this.Password),
                        FilterSettings = new RequestModel
                        {
                            Categories = AddCategories(),
                            //Limit
                            Search = this.Search,
                            Token = this.Token,
                        }
                    });
                    Debug.WriteLine("Przypisanie wartości do filtrow");
                    string jsonConfigModel = JsonConvert.SerializeObject(configObject);
                    File.WriteAllText("Config.json", jsonConfigModel);
                }

            }
            else
            {
                List<ConfigModel> configObject = new List<ConfigModel>();
                configObject.Add
                    (
                        new ConfigModel
                        {
                            Login = this.Login,
                            Password = BCrypt.Net.BCrypt.HashPassword(this.Password),
                            FilterSettings = new RequestModel
                            {
                                Categories = AddCategories(),
                                //Limit
                                Search = this.Search,
                                Token = this.Token,
                            }
                        }
                    );
                string jsonConfigModel = JsonConvert.SerializeObject(configObject);
                File.WriteAllText("Config.json", jsonConfigModel);
            }
            Debug.WriteLine("Its working");
            LoginPanelVisibility = false;
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
        private string AddCategories()
        {
            string categories = String.Empty;
            if (General)
                categories += "general,";
            if (Science)
                categories += "science,";
            if (Sports)
                categories += "sports,";
            if (Business)
               categories += "business,";
            if (Health)
                categories += "health,";
            if (Entertainment)
                categories += "entertainment,";
            if (Tech)
                categories += "tech,";
            if (Politics)
                categories += "politics,";
            if (Food)
                categories += "food,";
            if (Travel)
                categories += "travel,";
            if (!String.IsNullOrEmpty(categories))
                categories = categories
                .Remove(categories.Length - 1, 1);
            return categories;
        }
    }
}
