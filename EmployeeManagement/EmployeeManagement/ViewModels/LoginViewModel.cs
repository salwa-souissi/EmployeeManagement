using EmployeeManagement.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Input;
using EmployeeManagement.Models;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    class LoginViewModel : BaseViewModel
    {

       
        #region Properties



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

        #region Constructor without parametres
        public LoginViewModel()
        {


        }
        #endregion

        #region Constructor with parameters

        public LoginViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<LoginPage>.Get();



        }
        #endregion

        #region OnSubscribeCommand

        public ICommand OnSubscribeCommand => new Command( () =>
               {
                   var page1 = DependencyService.Get<SubscribeViewModel>() ?? (new SubscribeViewModel(_nav));

               });


        #endregion

        #region OnSubmitCommand Treatment


        public ICommand OnSubmitCommand => new Command(async () =>
               {


                   var user = await DataUser.GetAllAsync(x => x.Login.Equals(_login) && x.Password.Equals(_password));

                   if (user.Count() > 0)
                   {
                     

                       var page1 = DependencyService.Get<HomeViewModel>() ?? (new HomeViewModel(_nav));
                   }
                   else
                   {
                       Alerttitle = "Error";
                       Alertmsg = "Please verify your login and password";
                       DisplayPrompt();
                   }






               });

        #endregion


    }




}

