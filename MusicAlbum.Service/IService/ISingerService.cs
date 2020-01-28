using MusicAlbum.Model.ModelRec;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Service.Service
{
   public interface ISingerService
    {
        List<SingerModel> GetSingerDetailsByAlbumId(int albumId);
    }
}
