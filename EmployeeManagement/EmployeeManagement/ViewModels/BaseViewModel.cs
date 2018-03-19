using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Annotations;
using EmployeeManagement.Models;
using Root.Services.Sqlite;
using Xamarin.Forms;

namespace EmployeeManagement.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {

        #region DataBase

         public IDataStore<User> DataUser => DependencyService.Get<DataStore<User>>() ?? (new DataStore<User>("DataBase.db3"));
        public IDataStore<Employee> DataEmployee => DependencyService.Get<DataStore<Employee>>() ?? (new DataStore<Employee>("DataBase.db3"));

            
        #endregion
       
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Employee> _employeeList=new ObservableCollection<Employee>();

        public ObservableCollection<Employee> EmployeeList {
            get
            {
                return _employeeList;
            }
            set { SetProperty(ref _employeeList, value); } }

        public Action DisplayPrompt;
        public Action DisplayPromptWithValidation;


        public string Alerttitle { get; set; }
        public string Alertmsg { get; set; }

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

        #region Constructor without parametrs

        public BaseViewModel()
        {
            this.DisplayPrompt += () => CurrentPage.DisplayAlert(Alerttitle, Alertmsg, "ok");
            DataUser.CreateTableAsync();
            DataEmployee.CreateTableAsync();

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