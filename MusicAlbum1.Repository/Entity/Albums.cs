using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Entity
{
    public class Albums
    {
        [Key]
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public decimal AlbumPrice { get; set; }
        public DateTime AlbumReleaseDate { get; set; }
        public string AlbumImagPath { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
