using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Service.Service
{
    public interface IAlbumService
    {
        AlbumModel GetAlbumDetailsByAlbumId(int albumId);
    }
}
