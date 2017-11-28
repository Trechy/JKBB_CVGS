namespace JKBB_CVGS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cart")]
    public partial class Cart
    {
        public int CartID { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public int GameID { get; set; }

        public int Quantity { get; set; }

        public virtual User User { get; set; }

        public virtual Game Game { get; set; }
    }
}
