using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Views;
using Root.Services.Sqlite;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    class DetailsViewModel : BaseViewModel
    {
        public IDataStore<Employee> DataEmployee => DependencyService.Get<DataStore<Employee>>() ?? (new DataStore<Employee>("DataBase.db3"));


        #region Fields
        #endregion

        #region Properties
        public String title { get; set; }
        public String text { get; set; }
        private Employee Emp { get; set; }
        public INavigation  Nav
        {
            get
            {
                return _nav;
            }
            set { _nav = value; }
        }

        #endregion

        #region Constructor without parameter
        public DetailsViewModel()
        {

        }
        #endregion

        #region Constructor with parameters
        public DetailsViewModel(INavigation nav, Employee o)
        {
            _nav = nav;
            CurrentPage = DependencyInject<DetailsPage>.Get();
            OpenPage();
            CIN = o.CIN;
            Name = o.Name;
            GSM = o.GSM;
            Department = o.Department;
            Emp = o;

        }
        #endregion

        #region OnBackCommand Treatment
        public ICommand OnBackCommand => new Command(async () =>
        {

            await _nav.PopAsync();

        });
        #endregion


    }
}
