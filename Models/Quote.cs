using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models
{

    [Table("quotes")]
    public class Quote
    {

        public long id { get; set; }
        public string Full_Name { get; set; }
        public string Company_Name { get; set; }
        public string Phone_Number { get; set; }
    }
}