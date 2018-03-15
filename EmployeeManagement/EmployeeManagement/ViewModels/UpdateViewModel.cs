using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Views;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    class UpdateViewModel : BaseViewModel
    {

        #region Fields
        public Action DisplayPrompt;
        #endregion

        #region Properties

        public String title { get; set; }
        public String text { get; set; }

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

        #region Constructor without parameter
        public UpdateViewModel()
        {

        }
        #endregion

        #region Constructor with parameters
        public UpdateViewModel(INavigation nav)
        {
            _nav = nav;
            CurrentPage = DependencyInject<UpdatePage>.Get();
            OpenPage();
        }
        #endregion

        #region OnUpdateCommand Tratment 
        public ICommand OnUpdateCommand => new Command(async () =>
                {
                    foreach (Employee emp in EmployeeList)
                    {
                        if (emp._cin == _cin)
                        {
                            emp._cin = _cin;
                            emp._name = _name;
                            emp._gsm = _gsm;
                            emp._department = _department;
                           
                        }

                    }
                    var page = DependencyService.Get<HomeViewModel>() ?? (new HomeViewModel(_nav));


                });


        #endregion


      


    }
}

