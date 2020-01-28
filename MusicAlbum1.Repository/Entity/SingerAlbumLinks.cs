using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Entity
{
   public class SingerAlbumLinks
    {
        [Key]
        public int SingerAlbumId { get; set; }
        public int SingerId { get; set; }
        public int AlbumId { get; set; }
    }
}
