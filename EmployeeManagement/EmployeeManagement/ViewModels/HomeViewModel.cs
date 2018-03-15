using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Views;
using Xamarin.Forms;
using static Xamarin.Forms.DependencyService;

namespace EmployeeManagement.ViewModels
{
    partial class HomeViewModel : BaseViewModel
    {

        #region Fields
        public Command<Object> tapCommand;
        #endregion

        #region Properties

        public Command<Object> TappedCommand
        {
            get { return tapCommand; }
            set { tapCommand = value; }
        }


        public INavigation Nav
        {
            get
            {
                return _nav;
            }
            set { _nav = value; }
        }



        //   public ICommand OnAddCommand { protected set; get; }


        #endregion

        #region Constructor without parameters
        public HomeViewModel()
        {

        }

        #endregion

        #region Constructor with parameters

        public HomeViewModel(INavigation nav)
        {
            _nav = nav;
           CurrentPage = DependencyInject<HomePage>.Get();
           OpenPage(); 
            tapCommand = new Command<object>(OnTapped);
        }
        #endregion

        #region OnAddCommand Treatment
        public ICommand OnAddCommand => new Command(async () =>
              {

                  var page = DependencyService.Get<AddViewModel>() ?? (new AddViewModel(_nav));

              });
        #endregion
       
        #region OnTapped Method Implementation

        public void OnTapped(Object o)
        {
            var nextPage = new UpdatePage();
            nextPage.BindingContext = o;
            Nav.PushAsync(nextPage);
        }

        #endregion

       

    }


}

