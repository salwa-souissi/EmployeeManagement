using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EmployeeManagement.Annotations;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        #region Navigation
        public INavigation _nav;
        public ContentPage CurrentPage { get; set; }
        public virtual void OpenPage()
        {
            if (CurrentPage != null)
            {
                CurrentPage.BindingContext = this;
                _nav.PushAsync(CurrentPage);
            }
        }

        #endregion

       

        #region EmployeeList
        public ObservableCollection<Employee> EmployeeList { get; set; }
        #endregion

        #region Constructor without parametrs

        public BaseViewModel()
        {
            EmployeeList = new ObservableCollection<Employee>();

            EmployeeList.Add(new Employee
            {
                _cin = "01234567",
                _name = "Mohamed",
                _gsm = "22 011 011",
                _department = "FrontEnd"
            });
            EmployeeList.Add(
                new Employee
                {
                    _cin = "98765432",
                    _name = "Salah",
                    _gsm = "22 011 011",
                    _department = "BackEnd"
                });
            EmployeeList.Add(new Employee
            {
                _cin = "09834567",
                _name = "Ali",
                _gsm = "22 011 011",
                _department = "Services"
            });
            EmployeeList.Add(new Employee
            {
                _cin = "01247824",
                _name = "Hsan",
                _gsm = "22 011 011",
                _department = "Web API"

            });
        }
        #endregion

        #region IsBusy parameter

        bool isBusy = false;

        public bool IsBusy

        {

            get { return isBusy; }

            set { SetProperty(ref isBusy, value); }

        }



        #endregion

        #region Title  parameter

        string title = string.Empty;

        public string Title

        {

            get { return title; }

            set { SetProperty(ref title, value); }

        }


        #endregion

        #region SetProperty Method

        protected bool SetProperty<T>(ref T backingStore, T value,

           [CallerMemberName]string propertyName = "",

           Action onChanged = null)

        {

            if (EqualityComparer<T>.Default.Equals(backingStore, value))

                return false;



            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);

            return true;

        }


        #endregion

        #region INotifyPropertyChanged


        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")

        {

            var changed = PropertyChanged;

            if (changed == null)

                return;



            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        #endregion

    }

}