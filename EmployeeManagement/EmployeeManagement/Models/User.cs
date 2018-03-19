using System;
using System.Collections.Generic;
using System.Text;
using Root.Services.Sqlite;
using SQLite;

namespace EmployeeManagement.Models
{
    public class User : IBaseTable

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
