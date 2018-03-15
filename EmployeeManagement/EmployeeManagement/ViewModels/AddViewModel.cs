using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Views;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    class AddViewModel : BaseViewModel
    { 
        #region Fields
        public Action DisplayPrompt;

        #endregion

        #region Properties

        public String title { get; set; }
        public String text { get; set; }
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

        #region CIN Property
        public string _cin;
        public string CIN
        {
            get
            {
                return _cin;
            }
            set
            {
                SetProperty(ref _cin, value);
            }
        }

        #endregion

        #region Name Property
        public String _name;
        public String Name
        {
            get
            {
                return _name;

            }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        #endregion

        #region GSM Property
        public String _gsm;
        public String GSM
        {
            get
            {
                return _gsm;
            }
            set
            {
                SetProperty(ref _gsm, value);
            }
        }

        #endregion

        #region Department Property
        public String _department;
        public String Department
        {
            get
            {
                return _department;
            }
            set
            {
                SetProperty(ref _department, value);
            }
        }

        #endregion

        #region Constructor without parameters
        public AddViewModel()
        {

        }
        #endregion

        #region Constructor with parameter
        public AddViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<AddPage>.Get();
            OpenPage();
        }

        #endregion

        #region OnSubmitCommand Treatment

        public ICommand OnSubmitCommand => new Command(async () =>
         {
             EmployeeList.Add(new Employee
                 {_cin= _cin,
                     _name=_name,
                     _gsm=_gsm,
                     _department=_department });
             var page = DependencyService.Get<ViewModels.HomeViewModel>() ?? (new HomeViewModel(_nav));


         });

        #endregion

      
    }
}

