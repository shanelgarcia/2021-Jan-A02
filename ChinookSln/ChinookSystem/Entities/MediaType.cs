using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace ChinookSystem.Entities
{
    internal partial class MediaType
    {
        private string _Name;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MediaType()
        {
            Tracks = new HashSet<Track>();
        }

        public int MediaTypeId { get; set; }

        [StringLength(120, ErrorMessage = "Media type name is limited to 120 characters.")]
        public string Name { get { return _Name; } set { _Name = string.IsNullOrEmpty(value) ? null : value; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Track> Tracks { get; set; }
    }
}
