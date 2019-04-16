using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("leads")]
    public class Lead {
        [Key]
        public long id { get; set; }
        public long? customer_id { get; set; }
        public string full_name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string business_name { get; set; }
        public string project_name { get; set; }
        public string department { get; set; }
        public string project_description { get; set; }
        public string message { get; set; }
        //public Byte file_attachment { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        //public ICollection<Column> Columns { get; set; }
    }
}