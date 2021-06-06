using BCrypt.Net;
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
using System.Security;
using MvvmCross;
using NewsApp.Core.DataBase;
using NewsApp.Core.Helpers;

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
        private bool _IsCustomSettings;
        public bool IsCustomSettings
        {
            get => _IsCustomSettings;
            set
            {
                _IsCustomSettings = value;
                RaisePropertyChanged(() => IsCustomSettings);
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
        private String _password;
        public String Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        private string _loginMsg;
        public string LoginMsg
        {
            get => _loginMsg;
            set
            {
                _loginMsg = value;
                RaisePropertyChanged(() => LoginMsg);
            }
        }
        private String _passwordMsg;
        public String PasswordMsg
        {
            get => _passwordMsg;
            set
            {
                _passwordMsg = value;
                RaisePropertyChanged(() => PasswordMsg);
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
        private bool _loginPanelVisibility;
        public bool LoginPanelVisibility
        {
            get => _loginPanelVisibility;
            set
            {
                _loginPanelVisibility = value;
                RaisePropertyChanged(() => LoginPanelVisibility);
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
        private bool _IsPreferencesVisible;
        public bool IsPreferencesVisible
        {
            get => _IsPreferencesVisible;
            set
            {
                _IsPreferencesVisible = value;
                RaisePropertyChanged(() => IsPreferencesVisible);
            }
        }
        private bool _IsQSearchVisible;
        public bool IsQSearchVisible
        {
            get => _IsQSearchVisible;
            set
            {
                _IsQSearchVisible = value;
                RaisePropertyChanged(() => IsQSearchVisible);
            }
        }
        private bool _IsASearchVisible;
        public bool IsASearchVisible
        {
            get => _IsASearchVisible;
            set
            {
                _IsASearchVisible = value;
                RaisePropertyChanged(() => IsASearchVisible);
            }
        }
        private bool _IsFavoritesVisible;
        public bool IsFavoritesVisible
        {
            get => _IsFavoritesVisible;
            set
            {
                _IsFavoritesVisible = value;
                RaisePropertyChanged(() => IsFavoritesVisible);
            }
        }
        private bool _IsHistoryVisible;
        public bool IsHistoryVisible
        {
            get => _IsHistoryVisible;
            set
            {
                _IsHistoryVisible = value;
                RaisePropertyChanged(() => IsHistoryVisible);
            }
        }
        private bool _IsSignInVisible;
        public bool IsSignInVisible
        {
            get => _IsSignInVisible;
            set
            {
                _IsSignInVisible = value;
                RaisePropertyChanged(() => IsSignInVisible);
            }
        }
        private bool _IsSignIn;
        public bool IsSignIn
        {
            get => _IsSignIn;
            set
            {
                _IsSignIn = value;
                RaisePropertyChanged(() => IsSignIn);
            }
        }
        private bool _UserName;
        public bool UserName
        {
            get => _UserName;
            set
            {
                _UserName = value;
                RaisePropertyChanged(() => UserName);
            }
        }

        public IMvxCommand DoWorkCommand => new MvxCommand(DoWork, () => true);
        public IMvxCommand ShowPreferencesCommand => new MvxCommand(()=>ShowMenu("Preferences"), () => true);
        public IMvxCommand ShowQSearchCommand => new MvxCommand(()=>ShowMenu("QSearch"), () => true);
        public IMvxCommand ShowASearchCommand => new MvxCommand(()=>ShowMenu("ASearch"), () => true);
        public IMvxCommand ShowFavoritesCommand => new MvxCommand(()=>ShowMenu("Favorites"), () => true);
        public IMvxCommand ShowHistoryCommand => new MvxCommand(()=>ShowMenu("History"), () => true);
        public IMvxCommand ShowSignInCommand => new MvxCommand(()=>ShowMenu("SignIn"), () => true);
        public IMvxCommand SignInCommand => new MvxCommand(SignIn,() => true);
        #endregion

        private void DoWork()
        {
            
            LoginPanelVisibility = false;
            //ResultPanelVisibility = true;
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



        private void ShowMenu(string visibleMenu)
        {
            IsPreferencesVisible = false;
            IsQSearchVisible = false;
            IsASearchVisible = false;
            IsFavoritesVisible = false;
            IsHistoryVisible = false;
            IsSignInVisible = false;

            switch (visibleMenu)
            {
                case "Preferences":
                    IsPreferencesVisible = true;
                    break;
                case "QSearch":
                    IsQSearchVisible = true;
                    break;
                case "ASearch":
                    IsASearchVisible = true;
                    break;
                case "Favorites":
                    IsFavoritesVisible = true;
                    break;
                case "History":
                    IsHistoryVisible = true;
                    break;
                case "SignIn":
                    IsSignInVisible = true;
                    break;
                default:
                    break;
            };
        }
        private void SignIn()
        {
            #region checking textboxes content
            if (String.IsNullOrEmpty(Login))
            {
                LoginMsg = "Login is empty";
                return;
            }
            else
            {
                LoginMsg = "";
            }
            if (String.IsNullOrEmpty(Password))
            {
                PasswordMsg = "Password is empty";
                return;
            }
            else
            {
                PasswordMsg = "";
            }
            #endregion

            var pass = BCrypt.Net.BCrypt.HashPassword(new System.Net.NetworkCredential(string.Empty, this.Password).Password);
            //todo sprawdz konstruktor z parametrem
            var dll = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/");
            using (FirebaseGetUserResponse user = dll.GetUserData(DbRequestType.Users, Login))
            {

                if (user == null)
                {

                    FirebaseGetUserResponse userToAdd = new FirebaseGetUserResponse
                    {
                        credentials = new FirebaseGetUserResponse.Credentials
                        {
                            password = BCrypt.Net.BCrypt.HashPassword(new System.Net.NetworkCredential(string.Empty, this.Password).Password),
                            token = this.Token,
                            user = this.Login
                        },
                        preferences = new FirebaseGetUserResponse.Preferences
                        {
                            categories = AddCategories(),
                            search = this.Search,
                            language = this.Language,
                            //limit = 
                            published_after = this.DateFrom,
                            //published_before = this.DateTo,
                            domain = this.Domains,
                        }
                    };
                    if (dll.PutUserData(userToAdd, DbRequestType.Users, this.Login))
                        LoginMsg = "Użytkownik został dodany";
                }
                else
                {
                    if (BCrypt.Net.BCrypt.Verify(new System.Net.NetworkCredential(string.Empty, this.Password).Password
                       , user.credentials.password))
                    {
                        Debug.WriteLine("haslo sie zgadza");
                        IsSignIn = true;
                        SetLocalCategories(user.preferences.categories);
                        this.Domains = user.preferences.domain;
                        this.Language = user.preferences.language;
                        //this.limit = user.preferences.limit;
                        //this.ToDate = user.preferences.published_after;
                        this.DateFrom = user.preferences.published_before;
                    }
                    else
                    {
                        Debug.WriteLine("haslo sie nie zgadza");
                        IsSignIn = false;
                    }
                }
            }
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
        //public async Task<AllNews.Rootobject> GetNews(IRequestModel requestModel)
        //{
        //    var result = services.GetNews(requestModel);
        //    return JsonReader<AllNews.Rootobject>.JsonDeserialize(result.Content);
        //}
        public ObservableCollection<AllNewsModel> NewsList { get; set; } = new ObservableCollection<AllNewsModel>();

        private Random rand = new Random();

        private void Fill(AllNews.Rootobject allNews)
        {
            if (NewsList.Count > 0)
                NewsList.Clear();
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
        private void SetLocalCategories(string categories)
        {
            if (categories.Contains("general"))
                General = true;
            if (categories.Contains("science"))
                Science = true;
            if (categories.Contains("sports"))
                Sports = true;
            if (categories.Contains("business"))
                Business = true;
            if (categories.Contains("health"))
                Health = true;
            if (categories.Contains("entertainment"))
                Entertainment = true;
            if (categories.Contains("tech"))
                Tech = true;
            if (categories.Contains("politics"))
                Politics = true;
            if (categories.Contains("food"))
                Food = true;
            if (categories.Contains("travel"))
                Travel = true;
        }
    }
}
