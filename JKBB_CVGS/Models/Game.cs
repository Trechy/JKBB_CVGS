namespace JKBB_CVGS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Game")]
    public partial class Game
    {
        public int GameID { get; set; }

        [Required]
        [StringLength(25)]
        public string Title { get; set; }

        [Required]
        [StringLength(25)]
        public string Developer { get; set; }

        [Required]
        [StringLength(25)]
        public string Publisher { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReleasedDate { get; set; }

        public decimal BasePrice { get; set; }

        public double Discount { get; set; }
    }
}
