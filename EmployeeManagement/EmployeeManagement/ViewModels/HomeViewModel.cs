using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using EmployeeManagement.Services;
using EmployeeManagement.Views;
using Xamarin.Forms;
using static Xamarin.Forms.DependencyService;

namespace EmployeeManagement.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {

        #region Fields
        public Command<Object> updateCommand;
        public Command<Object> deleteCommand;

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
            Data d = new Data();
            _employeeList = d.EmployeeList;

            _nav = nav;
            CurrentPage = DependencyInject<HomePage>.Get();
            OpenPage();


            updateCommand = new Command<object>(OnUpdate);
            deleteCommand = new Command<object>(OnDelete);

        }

        #region Consructor with list

        public HomeViewModel(INavigation nav, ObservableCollection<Employee> emp)
        {

            EmployeeList = emp;

            _nav = nav;
            CurrentPage = DependencyInject<HomePage>.Get();
            OpenPage();


            updateCommand = new Command<object>(OnUpdate);
            deleteCommand = new Command<object>(OnDelete);

        }

        #endregion




        #endregion

        #region OnAddCommand Treatment
        public ICommand OnAddCommand => new Command(async () =>
              {

                  var page = DependencyService.Get<AddViewModel>() ?? (new AddViewModel(_nav, _employeeList));

              });
        #endregion

        #region OnUpdate Method Implementation

        public void OnUpdate(Object o)
        {
            Employee E = (Employee)o;
            var page = DependencyService.Get<UpdateViewModel>() ?? (new UpdateViewModel(_nav,E, _employeeList));


        }

        #endregion

        #region OnDelete Method Implementation

        public void OnDelete(Object o)
        {

            
            Employee E = (Employee)o;
            ObservableCollection<Employee> EmpList = _employeeList;
            if (EmpList.Contains(E))
            {
                EmpList.Remove(E);
            }
            EmployeeList = EmpList;
            }
        
        #endregion


    }


}

