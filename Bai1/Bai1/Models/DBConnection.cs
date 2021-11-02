﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Bai1.Models
{
    public class DBConnection
    {
        string strCon;
        public DBConnection()
        {
            strCon = ConfigurationManager.ConnectionStrings["ManagementBlogsConnectionString"].ConnectionString;

        }
        public SqlConnection getConnection()
        {
            return new SqlConnection(strCon);
        }

    }
}