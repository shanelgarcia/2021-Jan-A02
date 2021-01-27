using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ChinookSystem.Entities
{
    internal partial class Customer
    {
        private string _Company;
        private string _Address;
        private string _City;
        private string _State;
        private string _Country;
        private string _PostalCode;
        private string _Phone;
        private string _Fax;
        private string _Email;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int CustomerId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "First name is limited to 40 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Last name is limited to 20 characters.")]
        public string LastName { get; set; }

        [StringLength(80, ErrorMessage = "Company name  is limited to 80 characters.")]
        public string Company { get { return _Company; } set { _Company = string.IsNullOrEmpty(value) ? null : value; } }

        [StringLength(70, ErrorMessage = "Address is limited to 70 characters.")]
        public string Address
        {
            get { return _Address; }
            set { _Address = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "City is limited to 40 characters.")]
        public string City
        {
            get { return _City; }
            set { _City = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "State is limited to 40 characters.")]
        public string State
        {
            get { return _State; }
            set { _State = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(40, ErrorMessage = "Country is limited to 40 characters.")]
        public string Country
        {
            get { return _Country; }
            set { _Country = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(10, ErrorMessage = "Postal code is limited to 10 characters.")]
        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24, ErrorMessage = "Phone is limited to 24 characters.")]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = string.IsNullOrEmpty(value) ? null : value; }
        }

        [StringLength(24, ErrorMessage = "Fax is limited to 24 characters.")]
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = string.IsNullOrEmpty(value) ? null : value; }
        }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(60, ErrorMessage = "Email is limited to 60 characters.")]
        public string Email
        {
            get { return _Email; }
            set { _Email = string.IsNullOrEmpty(value) ? null : value; }
        }

        public int? SupportRepId { get; set; }

        public virtual Employee Employee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
