using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Model.ModelRec
{
  public class SingerModel
    {
        public int SingerId { get; set; }
        public string SingerName { get; set; }
        public string SingerReview { get; set; }  
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }

    }
}
