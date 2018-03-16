using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EmployeeManagement.Services
{
 public   class Data
    {
        #region EmployeeList

        public ObservableCollection<Employee> EmployeeList { get; set; }

        #endregion

        #region Constructor

        public Data()

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

        //#region LoadAllData Method

        //public ObservableCollection<Employee> LoadAllData()
        //{
        //    return EmployeeList;
        //}

        //#endregion

        //#region AddNewDataRow Method

        //public void AddNewDataRow(Employee emp)
        //{
        //    EmployeeList.Add(emp);
        //}


        //#endregion

        //#region UpdateDataRow Method

        //public void UpdateDataRow(Employee emp)
        //{
        //    foreach (Employee e in EmployeeList)
        //    {
        //        if (e._cin == emp._cin)

        //        {
        //            e._cin = emp._cin;
        //            e._name = emp._name;
        //            e._gsm = emp._gsm;
        //            e._department = emp._department;
        //        }
        //    }
        //}

        //#endregion

        //#region RemoveDataRow Method

        //public void RemoveDataRow(Employee emp)
        //{
        //    EmployeeList.Remove(emp);
        //}

        //#endregion


    }
}
