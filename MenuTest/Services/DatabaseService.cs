﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuTest.Services
{

    class DatabaseService
    {

        public static string GetConnectionString()
        {
            // return = "Data Source=(local);Initial Catalog=MenuShell;Integrated Security=true";
            return "Data Source=.\\MSSQLSERVER01;Initial Catalog=MenuShell;Integrated Security=true";
        }
    }
}
