using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("buildings")]
    public class Building {
        [Key]
        public long id { get; set; }
        public long customer_id {get; set;}
        public long address_id {get;set;}
        public string building_administrator_full_name {get; set;}
        public string building_administrator_email {get;set;}
        public string building_administrator_phone {get;set;}
        public string building_technical_contact_name {get;set;}
        public string building_technical_contact_email {get;set;}
        public string building_technical_contact_phone {get;set;}
    }
}