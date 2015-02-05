using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace ExemploDeUsoDapper.Models
{
    public class ConnectionBD
    {
        public ConnectionBD()
        {
            conection.Open();
        }
        public MySqlConnection conection = new MySqlConnection("Database=dappertest;Data Source=localhost;User Id=root; Password=root");
    }

}