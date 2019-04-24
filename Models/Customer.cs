using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("customers")]
    public class Customer
    {
        [Key]
        public long id { get; set; }
        public long address_id { get; set; }
        public string company_name { get; set; }
        public string full_name { get; set; }
        public string phone { get; set; }

    }
}