using Root.Services.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectUnitTest.Models
{
    public class Color : IBaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Colorcode { get; set; }
        public string Colorname { get; set; }


    }
}
