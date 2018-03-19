using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using EmployeeManagement.Services;
using EmployeeManagement.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static Xamarin.Forms.DependencyService;

namespace EmployeeManagement.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        #region Fields
        public Command<Object> updateCommand;
        public Command<Object> deleteCommand;
        public Command<Object> displaydetailsCommand;

        private Employee _oldEmployee;

        #endregion

        #region Properties

        public Command<Object> UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public Command<Object> DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }

        public Command<Object> DetailsDisplayCommand
        {
            get { return displaydetailsCommand; }
            set { displaydetailsCommand = value; }
        }

        public string _bar;

        public string Bar
        {
            get { return _bar; }
            set
            {
            SetProperty(ref _bar, value);
                var emplist = new ObservableCollection<Employee>();
                IEnumerable<Employee> searchresult = _employeeList.Where(emp => emp.Name.Contains(_bar));
                var l=  CurrentPage.FindByName<ListView>("list");
                l.ItemsSource = searchresult;

            }
        }
        
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
        public HomeViewModel()
        {

        }

        #endregion

        #region GetData Method

          public  async void GetData()
        {
            _employeeList.Clear();
            var emplist = await DataEmployee.GetAllAsync();
            foreach (Employee e in emplist)
            {
                _employeeList.Add(e);
            }
        }

        #endregion

        #region Constructor with parameters

        public HomeViewModel(INavigation nav)
        {
            GetData();
            _nav = nav;
            CurrentPage = DependencyInject<HomePage>.Get();
            OpenPage();

            updateCommand = new Command<object>(OnUpdate);
            deleteCommand = new Command<object>(OnDelete);
            DetailsDisplayCommand=new Command<object>(OnDetailsDisplay);
        }

        #endregion

        #region OnAddCommand Treatment
        public ICommand OnAddCommand => new Command( () =>
              {

                  var page = DependencyService.Get<AddViewModel>() ?? (new AddViewModel(_nav));

              });
        #endregion

        #region OnUpdate Method Implementation

        public void OnUpdate(Object o)
        {
            Employee E = (Employee)o;
            var page = DependencyService.Get<UpdateViewModel>() ?? (new UpdateViewModel(_nav, E));


        }

        #endregion

        #region OnDetailsDisplay Method Implementation

        public void OnDetailsDisplay(Object o)
        {
            Employee E = (Employee)o;
               var page = DependencyService.Get<DetailsViewModel>() ?? (new DetailsViewModel(_nav, E));
            
        }

        #endregion

        #region OnDelete Method Implementation

        public async void OnDelete(Object o)
        {

            Employee E = (Employee)o;
            var result = await CurrentPage.DisplayAlert("Alert!", "Are you sure you want to delete this employee?", "Yes", "No");
            if (result) 
            try
            {
                await DataEmployee.DeleteAsync(E);
                 GetData();
            }
            catch (Exception e)
            {
                await CurrentPage.DisplayAlert("no", "no", "ok");
            }



        }

        #endregion

        #region Methods form expandable list

        public void ShowOrHideEmployees(Employee employee)
        {
            if (_oldEmployee == employee)
            {
                // click twice on the same item will hide it
                employee.IsVisible = !employee.IsVisible;
                UpdateEmployees(employee);
            }
            else
            {
                if (_oldEmployee != null)
                {
                    // hide previous selected item
                    _oldEmployee.IsVisible = false;
                    UpdateEmployees(_oldEmployee);
                }
                // show selected item
                employee.IsVisible = true;
                UpdateEmployees(employee);
            }

            _oldEmployee = employee;
        }

        private void UpdateEmployees(Employee employee)
        {
            if (_employeeList.Contains(employee))
           {
                var index = _employeeList.IndexOf(employee);
                _employeeList.Remove(employee);
                _employeeList.Insert(index, employee);
            }
        }

        #endregion

       
    }


}

