﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespace
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace ChinookSystem.Entities
{
    [Table("Tracks")]
    class Track
    {
        private string _Name;
        private string _Composer;

        [Key]
        public int TrackId { get; set; }
        [StringLength(200, ErrorMessage = "Track name is limited to 200 characters.")]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public int? AlbumId { get; set; }
        public int MediaTypeId{ get; set; }
        public int? GenreId { get; set; }
        public string Composer
        {
            get
            {
                return _Composer;
            }
            set
            {
                _Composer = string.IsNullOrEmpty(value) ? null : value;
            }
        }
        public int Milliseconds { get; set; }
        public int? Bytes { get; set; }
        //numeric
        public double UnitPrice{ get; set; }

        public virtual ICollection<Track> Tracks { get; set; }
    }
}
