using SportBook.Libraries.DBCommunication;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace SmartAgri.DataBase.Models.Models
{
    public class Season
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        //public int Year { get; set; }
        //public string FieldId { get; set; }
        //public int SeedId { get; set; }

        public Season(IDataReader data)
        {
            Id = data.GetRecord<int>("id");
            Name = data.GetRecord<string>("name");
            //Year = data.GetRecord<int>("season_id");
            //FieldId = data.GetRecord<string>("field_id");
            //SeedId = data.GetRecord<int>("seed_id");
        }

        public Season()
        {

        }
    }
}
