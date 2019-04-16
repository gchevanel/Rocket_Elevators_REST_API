using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RocketElevatorApi.Models {

    [Table("interventions")]
    public class Intervention {
        [Key]
        public long id { get; set; }
        public string Author { get; set; }
        public long? Customer_id { get; set; }
        public long? Building_id { get; set; }
        public long? Battery_id { get; set; }
        public long? Column_id { get; set; }
        public long? Elevator_id { get; set; }
        public long? Employee_id { get; set; }
        public DateTime? InterventionStartingDate { get; set; }
        public DateTime? InterventionFinishedDate { get; set; }

        public string Result { get; set; }
        public string Report { get; set; }
        public string Status { get; set; }

        //public ICollection<Column> Columns { get; set; }
    }
}