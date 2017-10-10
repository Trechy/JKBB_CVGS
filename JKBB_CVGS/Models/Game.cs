namespace JKBB_CVGS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public int GameID { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Developer")]
        public string Developer { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Publisher")]
        public string Publisher { get; set; }

        [Column(TypeName = "date")]
        [DisplayName("Release Date")]
        public DateTime ReleasedDate { get; set; }

        [DisplayName("Price")]
        public decimal BasePrice { get; set; }

        [DisplayName("Discount")]
        public double Discount { get; set; }
    }
}
