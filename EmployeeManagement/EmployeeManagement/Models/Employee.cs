using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using EmployeeManagement.Annotations;
using Root.Services.Sqlite;
using SQLite;

namespace EmployeeManagement
{
    public class Employee : IBaseTable

    {[PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string CIN { get; set; }
        public string Name { get; set; }
        public string GSM { get; set; }
        public string Department { get; set; }
        public bool IsVisible { get; set; }


       
       

     


       
    }
}
