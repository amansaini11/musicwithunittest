using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Model.ModelRec
{
  public  class AlbumModel
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public string AlbumImagePath { get; set; }
        public DateTime AlbumReleaseDate { get; set; }
        public decimal AlbumPrice { get; set; }
        public int AlbumRatingId { get; set; }
        public int? AlbumRatings { get; set; }
    }
}
