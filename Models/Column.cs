using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("columns")]
    public class Column {
        public long id { get; set; }
        public long battery_id { get; set; }
        public string status { get; set; }
    }
}