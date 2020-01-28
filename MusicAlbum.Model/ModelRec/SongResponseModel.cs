using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Model.ModelRec
{
    public class SongResponseModel
    {
        public string SingerName { get; set; }
        public int SingerId { get; set; }
        public string SongName { get; set; }
        public TimeSpan SongDuration { get; set; }
        public decimal SongPrice { get; set; }
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public int? SongPopularity { get; set; }

    }
}
