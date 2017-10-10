namespace JKBB_CVGS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        public int EventID { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Name")]
        public string EventName { get; set; }

        [DisplayName("Date")]
        public DateTime EventDate { get; set; }

        [DisplayName("Description")]
        [Required]
        public string Description { get; set; }
    }
}
