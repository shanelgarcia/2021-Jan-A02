using System;
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
    [Table("Albums")]
    internal class Album
    {
        private string _ReleaseLabel;

        [Key]
        public int AlbumID { get; set; }
        [Required(ErrorMessage = "Album Title is required.")]
        [StringLength(160, ErrorMessage = "Album title is limited to 160 characters.")]
        public string Title { get; set; }
        public int ArtistID { get; set; }

        [Required(ErrorMessage = "Album Title is required.")]
        public int ReleaseDate { get; set; }
        [StringLength(50, ErrorMessage = "Album release label is limited to 50 characters.")]
        public string ReleaseLael
        {
            get
            {
                return _ReleaseLabel;
            }
            set
            {
                _ReleaseLabel = string.IsNullOrEmpty(value) ? null : value;
            }
        }

        //[NotMapped] annon are also allowed
        //Navigational properties are not real data. Keyword: virtual 

        public virtual Artist Artist { get; set; }

    }
}
