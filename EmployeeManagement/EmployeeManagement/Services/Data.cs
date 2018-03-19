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
                CIN = "01234567",
                Name = "Mohamed",
                GSM = "22 011 011",
                Department = "FrontEnd"
            });
            EmployeeList.Add(
                new Employee
                {
                    CIN = "98765432",
                    Name = "Salah",
                    GSM = "22 011 011",
                    Department = "BackEnd"
                });
            EmployeeList.Add(new Employee
            {
                CIN = "09834567",
                Name = "Ali",
                GSM = "22 011 011",
                Department = "Services"
            });
            EmployeeList.Add(new Employee
            {
                CIN = "01247824",
                Name = "Hsan",
                GSM = "22 011 011",
                Department = "Web API"

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
        //        if (e.CIN == emp.CIN)

        //        {
        //            e.CIN = emp.CIN;
        //            e.Name = emp.Name;
        //            e.GSM = emp.GSM;
        //            e.Department = emp.Department;
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
