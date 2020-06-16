using System;

namespace Airline.DAL
{
    public class MyConnection
    {   //add-migration "name"
        //update-database
        //Scaffold-DbContext "Data Source=DESKTOP\\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer
        public static string Connection = @"Data Source=DESKTOP\SQLEXPRESS;Initial Catalog=Airline;Integrated Security=True";
    }
}
