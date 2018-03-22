using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Services;
using EmployeeManagement.Views;
using Root.Services.Sqlite;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
 public   class AddViewModel : BaseViewModel
    {
        public IDataStore<Employee> DataEmployee => DependencyService.Get<DataStore<Employee>>() ?? (new DataStore<Employee>("DataBase.db3"));


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
            Employee Emp = new Employee
            {
                CIN = _cin,
                Name = _name,
                GSM = _gsm,
                Department = _department,
                IsVisible=false
            };


            try
            {
                await DataEmployee.AddAsync(Emp);
                await _nav.PopAsync();

            }
            catch (Exception e)
            {
                await CurrentPage.DisplayAlert("no", e.Message, "ok");
            }



        });

        #endregion


    }
}

