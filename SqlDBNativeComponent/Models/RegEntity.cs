using System;
using SQLite;

namespace SqlDBNativeComponent.Models
{
    public class RegEntity
    {
        public RegEntity()
        {
        }
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
