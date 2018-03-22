using Root.Services.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectUnitTest.Models
{
    public class Product :IBaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ColorId { get; set; }
        public int MesearementId { get; set; }
    }
}
