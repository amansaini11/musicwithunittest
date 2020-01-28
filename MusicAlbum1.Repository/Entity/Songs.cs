using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Entity
{
  public class Songs
    {
        [Key]
        public int SongId { get; set; }
        public int AlbumId { get; set; }
        public int SingerId { get; set; }
        public string SongName { get; set; }
        public TimeSpan SongDuration { get; set; }
        public decimal SongPrice { get; set; }    
        public int? SongPopularity { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
