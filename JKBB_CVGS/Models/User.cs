namespace JKBB_CVGS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Carts = new HashSet<Cart>();
            Wishlists = new HashSet<Wishlist>();
            Events = new HashSet<Event>();
        }

        private string email;
        private string password;
        private string role;
        private string firstName;
        private string lastName;
        private string gender;
        private DateTime dateOfBirth;
        private string address;
        private string city;
        private string province;
        private string postalCode;
        private string phoneNumber;

        [Key]
        [StringLength(50)]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value.Trim();
            }
        }


        [Required]
        [StringLength(25)]
        public string Password
        {
            get
            {
                return this.password;
            }
            set
            {
                this.password = value.Trim();
            }
        }

        [Required]
        [StringLength(25)]
        public string Role
        {
            get
            {
                return this.role;
            }
            set
            {
                this.role = value.Trim();
            }
        }

        [Required]
        [StringLength(25)]
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value.Trim();
            }
        }

        [Required]
        [StringLength(25)]
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value.Trim();
            }
        }

        [StringLength(1)]
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = (value == null) ? "" : value.Trim(); ;
            }
        }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth
        {
            get;
            set;
        }

        [StringLength(50)]
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = (value == null) ? "" : value.Trim(); ;
            }
        }

        [StringLength(25)]
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = (value == null) ? "" : value.Trim(); ;
            }
        }

        [StringLength(25)]
        public string Province
        {
            get
            {
                return this.province;
            }
            set
            {
                this.province = (value == null) ? "" : value.Trim(); ;
            }
        }

        [StringLength(6)]
        public string PostalCode
        {
            get
            {
                return this.postalCode;
            }
            set
            {
                this.postalCode = (value == null) ? "" : value.Trim(); ;
            }
        }

        [StringLength(10)]
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }
            set
            {
                this.phoneNumber = (value == null) ? "" : value.Trim(); ;
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Wishlist> Wishlists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }
    }
}
