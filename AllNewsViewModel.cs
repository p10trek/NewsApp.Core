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
        private DateTime _DateTo;
        public DateTime DateTo
        {
            get => _DateTo;
            set
            {
                _DateTo = value;
                RaisePropertyChanged(() => DateTo);
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
        private bool _IsFavListVisible;
        public bool IsFavListVisible
        {
            get => _IsFavListVisible;
            set
            {
                _IsFavListVisible = value;
                RaisePropertyChanged(() => IsFavListVisible);
            }
        }
        private bool _IsSignInButtonVisible = true;
        public bool IsSignInButtonVisible
        {
            get => _IsSignInButtonVisible;
            set
            {
                _IsSignInButtonVisible = value;
                RaisePropertyChanged(() => IsSignInButtonVisible);
            }
        }
        private bool _IsLogOutButtonVisible;
        public bool IsLogOutButtonVisible
        {
            get => _IsLogOutButtonVisible;
            set
            {
                _IsLogOutButtonVisible = value;
                RaisePropertyChanged(() => IsLogOutButtonVisible);
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
        private int _selectedTMP;
        private int _SelectedItem;
        public int SelectedItem
        {
            get => _SelectedItem;
            set
            {
                _SelectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }
        private int _Limit;
        public int Limit
        {
            get => _Limit;
            set
            {
                _Limit = value;
                RaisePropertyChanged(() => Limit);
            }
        }
        private bool _IsWebBrowserVisible;
        public bool IsWebBrowserVisible
        {
            get => _IsWebBrowserVisible;
            set
            {
                _IsWebBrowserVisible = value;
                RaisePropertyChanged(() => IsWebBrowserVisible);
            }
        }
        private Uri _SelectedURL;
        public Uri SelectedURL
        {
            get => _SelectedURL;
            set
            {
                _SelectedURL = value;
                RaisePropertyChanged(() => SelectedURL);
            }
        }
        private List<string> _FavoritesList;
        public List<string> FavoritesList
        {
            get => _FavoritesList;
            set
            {
                _FavoritesList = value;
                RaisePropertyChanged(() => FavoritesList);
            }
        }
        private int _SelectedFav;
        public int SelectedFav
        {
            get => _SelectedFav;
            set
            {
                _SelectedFav = value;
                RaisePropertyChanged(() => SelectedFav);
                ShowFavorite();
            }
        }
        private int _SelectedHist;
        public int SelectedHist
        {
            get => _SelectedHist;
            set
            {
                _SelectedHist = value;
                RaisePropertyChanged(() => SelectedHist);
                ShowHistoricalSearch();
            }
        }
        private List<string> _HistoryList;
        public List<string> HistoryList
        {
            get => _HistoryList;
            set
            {
                _HistoryList = value;
                RaisePropertyChanged(() => HistoryList);
            }
        }
        private bool _IsHistoryListVisible;
        public bool IsHistoryListVisible
        {
            get => _IsHistoryListVisible;
            set
            {
                _IsHistoryListVisible = value;
                RaisePropertyChanged(() => IsHistoryListVisible);
            }
        }
        private bool _IsCustomSetVisible;
        public bool IsCustomSetVisible
        {
            get => _IsCustomSetVisible;
            set
            {
                _IsCustomSetVisible = value;
                RaisePropertyChanged(() => IsCustomSetVisible);
            }
        }

        private bool _IsWebViewMenuVisible;
        public bool IsWebViewMenuVisible
        {
            get => _IsWebViewMenuVisible;
            set
            {
                _IsWebViewMenuVisible = value;
                RaisePropertyChanged(() => IsWebViewMenuVisible);
            }
        }

        private bool _IsFavViewMenuVisible;
        public bool IsFavViewMenuVisible
        {
            get => _IsFavViewMenuVisible;
            set
            {
                _IsFavViewMenuVisible = value;
                RaisePropertyChanged(() => IsFavViewMenuVisible);
            }
        }

        public IMvxCommand DoWorkCommand => new MvxCommand(SearchNews, () => true);
        public IMvxCommand SavePreferencesCommand => new MvxCommand(SavePreferences, () => true);
        public IMvxCommand ShowPreferencesCommand => new MvxCommand(()=>ShowMenu("Preferences"), () => true);
        public IMvxCommand ShowQSearchCommand => new MvxCommand(()=>ShowMenu("QSearch"), () => true);
        public IMvxCommand ShowASearchCommand => new MvxCommand(()=>ShowMenu("ASearch"), () => true);
        public IMvxCommand ShowFavoritesCommand => new MvxCommand(()=>ShowMenu("Favorites"), () => true);
        public IMvxCommand ShowHistoryCommand => new MvxCommand(()=>ShowMenu("History"), () => true);
        public IMvxCommand ShowSignInCommand => new MvxCommand(()=>ShowMenu("SignIn"), () => true);
        public IMvxCommand SignInCommand => new MvxCommand(SignIn,() => true);
        public IMvxCommand AddToFavoritesCommand => new MvxCommand(AddToFavorites, () => true);
        public IMvxCommand ShowBrowserCommand => new MvxCommand(ShowBrowser, () => true);
        public IMvxCommand LogOutCommand => new MvxCommand(LogOut, () => true);
        public IMvxCommand BackToListCommand => new MvxCommand(BackToList, () => true);
        public IMvxCommand BackToFavoritesCommand => new MvxCommand(BackToFavorites, () => true);
        
        #endregion

        private void SearchNews()
        {
            LoginPanelVisibility = false;
            //ResultPanelVisibility = true;
            IRequestModel requestModel = new RequestModel();
            requestModel.Categories = AddCategories();
            if (!String.IsNullOrEmpty(this.Domains))
            requestModel.domains = this.Domains;
            if (!String.IsNullOrEmpty(this.Language))
            requestModel.language = this.Language;
            
            requestModel.published_after = this.DateFrom;
            requestModel.published_before = this.DateTo;
            if (!String.IsNullOrEmpty(this.Search))
                requestModel.Search = this.Search;
            if (!String.IsNullOrEmpty(this.Limit.ToString()))
                requestModel.Limit = this.Limit;
            requestModel.Timeout = -1;

#if DEBUG
            requestModel.Token = "HgcpXI8z8J7yLHOCfRxpluxoGgUA7zYbGmq5PdAR";
#endif
            requestModel.Url = "https://api.thenewsapi.com/v1/news/all";
            string login = IsSignIn == true ? Login : String.Empty;
            var result = services.GetNews(requestModel, login);
            AllNews.Rootobject allNews =  JsonReader<AllNews.Rootobject>.JsonDeserialize(result.Content);
            Fill(allNews);
            ResultPanelVisibility = true;
        }
        public void ShowHistoricalSearch()
        {
            var result = services.GetNews(HistoryList[SelectedHist]);
            AllNews.Rootobject allNews = JsonReader<AllNews.Rootobject>.JsonDeserialize(result.Content);
            Fill(allNews);
            IsHistoryListVisible = false;
            ResultPanelVisibility = true;
        }
        public void ShowBrowser()
        {
            Debug.WriteLine(SelectedItem);
            ResultPanelVisibility = false;

            IsWebBrowserVisible = true;
            IsWebViewMenuVisible = true;
            _selectedTMP = SelectedItem;
            SelectedURL = new Uri(NewsList[SelectedItem].url);
        }
        public void ShowFavorite()
        {
            Debug.WriteLine(SelectedItem);
            ResultPanelVisibility = false;
            IsFavListVisible = false;
            IsFavViewMenuVisible = true;
            IsWebBrowserVisible = true;
            SelectedURL = new Uri(FavoritesList[SelectedFav]);
        }
        private void BackToList()
        {
            IsWebBrowserVisible = false;
            SelectedURL = new Uri("about:blank");
            ResultPanelVisibility = true;
        }
        private void BackToFavorites()
        {
            IsWebBrowserVisible = false;
            SelectedURL = new Uri("about:blank");
            IsFavListVisible = true;
        }

        public void SavePreferences()
        {
            if (IsSignIn) 
            {
                var dll = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/Users/{node}");
                var preferencse = new Preferences
                {
                    Categories = AddCategories(),
                    domains = this.Domains,
                    Limit = this.Limit,
                    published_after = this.DateFrom,
                    published_before = this.DateTo,
                    language = this.Language,
                    Search = this.Search
                };
                if (dll.PutUserData(preferencse, DbRequestType.Preferences, this.Login));
            }
        }
        public void AddToFavorites()
        {
            List<string> fav = new List<string>();
            var dll = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/Users/{node}");
            var data = dll.GetUserInfo(this.Login, DbRequestType.Favorites);
            if (data != null)
                fav.AddRange(data);
            if (!fav.Contains(NewsList[_selectedTMP].url))
            {
                fav.Add(NewsList[_selectedTMP].url);
                dll.PutUserData(fav, DbRequestType.Favorites, this.Login);
            }
        }

        private void ShowMenu(string visibleMenu)
        {
            IsPreferencesVisible = false;
            IsQSearchVisible = false;
            IsASearchVisible = false;
            IsFavoritesVisible = false;
            IsHistoryVisible = false;
            IsSignInVisible = false;
            IsFavListVisible = false;
            IsHistoryListVisible = false;
            switch (visibleMenu)
            {
                case "Preferences":
                    ResultPanelVisibility = true;
                    IsPreferencesVisible = true;
                    break;
                case "QSearch":
                    ResultPanelVisibility = true;
                    IsQSearchVisible = true;
                    break;
                case "ASearch":
                    ResultPanelVisibility = true;
                    IsASearchVisible = true;
                    break;
                case "Favorites":
                    ResultPanelVisibility = false;
                    NewsList.Clear();
                    IsWebBrowserVisible = false;
                    SelectedURL = new Uri("about:blank");
                    ResultPanelVisibility = false;
                    IsFavoritesVisible = true;
                    var dll = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/Users/{node}");
                    this.FavoritesList = dll.GetUserInfo(this.Login, DbRequestType.Favorites);
                    IsFavListVisible = true;
                    break;
                case "History":
                    ResultPanelVisibility = false;
                    NewsList.Clear();
                    IsWebBrowserVisible = false;
                    SelectedURL = new Uri("about:blank");
                    ResultPanelVisibility = false;
                    IsHistoryVisible = true;
                    var dllh = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/Users/{node}");
                    this.HistoryList = dllh.GetUserInfo(this.Login, DbRequestType.History);
                    IsHistoryListVisible = true;
                    break;
                case "SignIn":
                    ResultPanelVisibility = true;
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

            var dll = GenericFactory<DLL>.CreateInstance("https://newsapp-292a3-default-rtdb.europe-west1.firebasedatabase.app/Users/{node}");
            using (FirebaseGetUserResponse user = dll.GetUserData(DbRequestType.Users, Login))
            {

                if (user?.Credentials == null)
                {

                    FirebaseGetUserResponse userToAdd = new FirebaseGetUserResponse
                    {
                        Credentials = new FirebaseGetUserResponse.Credentials_
                        {
                            password = BCrypt.Net.BCrypt.HashPassword(new System.Net.NetworkCredential(string.Empty, this.Password).Password),
                            token = this.Token,
                            login = this.Login
                        },
                        Preferences = new FirebaseGetUserResponse.Preferences_
                        {
                            categories = AddCategories(),
                            search = this.Search,
                            language = this.Language,
                            published_after = DateTime.Now.AddYears(-20),
                            published_before = DateTime.Now.AddYears(1),
                            domain = this.Domains
                        }
                    };
                    if (dll.PutUserData(userToAdd, DbRequestType.Users, this.Login))
                    {

                        IsSignIn = true;
                        if (userToAdd?.Preferences != null)
                        {
                            SetLocalCategories(userToAdd.Preferences.categories);     
                            this.Domains = userToAdd.Preferences.domain;
                            this.Language = userToAdd.Preferences.language;
                            this.Limit = userToAdd.Preferences.limit;
                            this.DateTo = userToAdd.Preferences.published_before;
                            this.DateFrom = userToAdd.Preferences.published_after;
                        }
                        IsSignIn = true;
                        IsSignInVisible = false;
                        IsSignInButtonVisible = false;
                        IsLogOutButtonVisible = true;
                        IsCustomSetVisible = true;
                        LoginMsg = "Użytkownik został dodany";
                    } 
                }
                else
                {//todo zapis preferencji niszczy poświadczenia i reszte
                    if (BCrypt.Net.BCrypt.Verify(new System.Net.NetworkCredential(string.Empty, this.Password).Password
                       , user.Credentials.password))
                    {
                        IsSignIn = true;
                        SetLocalCategories(user.Preferences.categories);
                        this.Domains = user.Preferences.domain;
                        this.Language = user.Preferences.language;
                        this.Limit = user.Preferences.limit;
                        this.DateTo = user.Preferences.published_before;
                        this.DateFrom = user.Preferences.published_after;
                        IsSignInVisible = false;
                        IsSignInButtonVisible = false;
                        IsLogOutButtonVisible = true;
                        IsCustomSetVisible = true;
                    }
                    else
                    {
                        Debug.WriteLine("haslo sie nie zgadza");
                        LoginMsg = "Niepoprawny login i/lub hasło";
                        LogOut();
                    }
                }
            }
            this.Password = String.Empty;
        }
        private void LogOut()
        {
            this.Business = false;
            this.DateFrom = new DateTime();
            this.Domains = String.Empty;
            this.Entertainment = false;
            this.Food = false;
            this.General = false;
            this.Health = false;
            this.Language = String.Empty;
            this.Login = String.Empty;
            this.Password = String.Empty;
            this.Politics = false;
            this.Science = false;
            this.Search = String.Empty;
            this.Sports = false;
            this.Tech = false;
            this.Travel = false;
            this.IsSignIn = false;
            this.IsCustomSetVisible = false;
            this.IsLogOutButtonVisible = false;
            this.IsQSearchVisible = false;
            this.IsSignInButtonVisible = true;
            this.IsFavoritesVisible = false;
            this.IsHistoryVisible = false;
            this.IsASearchVisible = false;
            this.IsPreferencesVisible = false;
            this.IsSignInVisible = true;
            this.NewsList.Clear();
            this.SelectedURL = null;
            this.IsWebBrowserVisible = false;
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
                    Title = news.title,
                    NewsGuid = new Guid(news.uuid),
                    url = news.url

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
