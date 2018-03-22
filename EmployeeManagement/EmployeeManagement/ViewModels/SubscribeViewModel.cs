using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Models;
using Xamarin.Forms;
using EmployeeManagement.Views;
using Root.Services.Sqlite;


namespace EmployeeManagement.ViewModels
{
   public class SubscribeViewModel : BaseViewModel
    {

        public IDataStore<User> DataUser => DependencyService.Get<DataStore<User>>() ?? new DataStore<User>("DataBase.db3");
        private readonly IDependencyService _dependencyService;

        #region Properties

        private INavigation _navigation;

        public INavigation Nav
        {
            get
            {
                return _nav;
            }
            set { _nav = value; }
        }

        #endregion

        #region Login Property
        public String _login;

        public String Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                SetProperty(ref _login, value);
            }
        }

        #endregion

        #region Password Property
        public String _password;

        public String Password
        {
            get
            {
                return _password;

            }
            set
            {
                _password = value;
                SetProperty(ref _password, value);
            }
        }
        #endregion

        #region Constructor without parameters
        //public SubscribeViewModel() : this(new DependencyServiceWrapper())
        //{

        //}
        #endregion

        #region Constructor with parameter
        public SubscribeViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<SubscribePage>.Get();
            OpenPage();
          
        }



        #endregion

        #region OnSubscribeCommand Treatment

        public ICommand OnSubscribeCommand => new Command(async () =>
        {
            User user = new User();
            user.Login = _login;
            user.Password = _password;
            try
            {
             await   DataUser.AddAsync(user);
             await _nav.PopAsync();

            }
            catch (Exception e)
            {
                await CurrentPage.DisplayAlert("no", "no", "ok");
            }


        });

        #endregion
    }
}
