using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("batteries")]
    public class Battery {
        [Key]
        public long id { get; set; }
        public long building_id { get; set; }
        [ForeignKey("building_id")]
        public string battery_type { get; set; }
        public string status { get; set; }
    }
}