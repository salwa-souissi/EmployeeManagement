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
 public   class UpdateViewModel : BaseViewModel
    {
        public IDataStore<Employee> DataEmployee => DependencyService.Get<DataStore<Employee>>() ?? (new DataStore<Employee>("DataBase.db3"));


        #region Fields
        public Action DisplayPrompt;
        #endregion

        #region Properties
        public String title { get; set; }
        public String text { get; set; }
        private Employee Emp { get; set; }
        public INavigation Nav
        {
            get
            {
                return _nav;
            }
            set { _nav = value; }
        }

        #endregion

        #region Constructor without parameter
        public UpdateViewModel()
        {

        }
        #endregion

        #region Constructor with parameters
        public UpdateViewModel(INavigation nav, Employee o)
        {
            _nav = nav;
            CurrentPage = DependencyInject<UpdatePage>.Get();
            OpenPage();
            CIN = o.CIN;
            Name = o.Name;
            GSM = o.GSM;
            Department = o.Department;
            Emp = o;

        }
        #endregion

        #region OnUpdateCommand Tratment 
        public ICommand OnUpdateCommand => new Command(async () =>
        {

            await DataEmployee.GetAllAsync(x => x.Id.Equals(Emp.Id));

            Emp.CIN = _cin;
            Emp.Name = _name;
            Emp.GSM = _gsm;
            Emp.Department = _department;


            try
            {
                await DataEmployee.UpdateAsync(Emp);
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

