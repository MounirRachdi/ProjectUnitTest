using Root.Services.Sqlite;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectUnitTest.Models
{
   public class Mesearement : IBaseTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
    }
}
