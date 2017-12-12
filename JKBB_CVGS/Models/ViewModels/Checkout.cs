using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JKBB_CVGS.Models.ViewModels
{
    public class Checkout
    {
        [Required]
        [StringLength(16)]
        [DisplayName("Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Cardholder Name")]
        public string CardholderName { get; set; }

        [Required]
        [StringLength(5)]
        [DisplayName("Expiry Date")]
        public string ExpiryDate { get; set; }

        [Required]
        [StringLength(3)]
        [DisplayName("Security Code")]
        public string SecurityCode { get; set; }
    }
}