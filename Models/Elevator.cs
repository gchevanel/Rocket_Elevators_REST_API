using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("elevators")]
    public class Elevator {
        [Key]
        public long id { get; set; }
        [ForeignKey("column_id")]
        public long column_id { get; set; }
        public string status { get; set; }
    }
}