using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.ViewModels
{
    class MenuViewModel
    {
        public MenuViewModel()
        {
            MenuList = new List<String>
            {
                "HOME",
                "MY ACCOUNT",
                "ALL EMPLOYEES",
                "LOGOUT"
            };
        }

        public List<string> MenuList { get; set; }
    }
}
