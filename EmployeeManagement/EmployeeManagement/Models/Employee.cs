using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EmployeeManagement.Annotations;

namespace EmployeeManagement
{
    public class Employee : INotifyPropertyChanged
    {
        #region Constructor without parameters
        public Employee()
        {

        }
        #endregion

        #region Constructor with parameters
        public Employee(string cin, string name, string gsm, string department)
        {
            _cin = cin;
            _name = name;
            _gsm = gsm;
            _department = department;
        }
        #endregion

        #region Property CIN
        public string _cin;
        public string CIN
        {
            get
            {
                return _cin;

            }
            set
            {
                if (_cin != value)
                {
                    _cin = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("CIN"));
                }
            }
        }
        #endregion

        #region Property Name
        public string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Name"));
                }
            }
        }
        #endregion

        #region Property GSM
        public string _gsm;

        public string GSM
        {
            get
            {
                return _gsm;

            }
            set
            {
                if (_gsm != value)
                {
                    _gsm = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("GSM"));
                }
            }
        }
        #endregion

        #region Property Department
        public string _department;
        public string Department
        {
            get
            {
                return _department;

            }
            set
            {
                if (_department != value)
                {
                    _department = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("Department"));
                }
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

       




    }
}
