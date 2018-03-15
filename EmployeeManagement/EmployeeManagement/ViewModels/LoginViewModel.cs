using EmployeeManagement.Views;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    class LoginViewModel : BaseViewModel
    {

        #region Fields
        public Action DisplayPrompt;
        #endregion

        #region Properties

        public string title { get; set; }
        public string text { get; set; }

        public INavigation Nav
        {
            get
            {
                return _nav;
            }set { _nav=value; }
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
        
        #region Constructor without parametres
        public LoginViewModel()
        {

        }
        #endregion

        #region Constructor with parameters

        public LoginViewModel(INavigation nav)
        {
            _nav= nav ;
            CurrentPage = DependencyInject<LoginPage>.Get();
        }
        #endregion

        #region OnSubmitCommand Treatment


        public ICommand OnSubmitCommand => new Command(async () => 
               {
               if (_login != "salwa" || _password != "salwa")
               {
                   title = "Error";
                   text = "Please verify your login and password";
                   DisplayPrompt();
               }
               else
               {
                 
                   }
                   var page1 = DependencyService.Get<HomeViewModel>() ?? (new HomeViewModel(_nav));
               });

        #endregion


    }




}

