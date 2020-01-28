using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Entity
{
   public class AlbumRating
    {
        [Key]
        public int AlbumRatingId { get; set; }
        public int AlbumId { get; set; }
        public int AlbumRatings { get; set; }
        public int AlbumRatingBy { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
