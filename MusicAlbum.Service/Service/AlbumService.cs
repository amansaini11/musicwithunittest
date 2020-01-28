using MusicAlbum.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Entity;

namespace MusicAlbum.Service.Service
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumsRepository _albumsRepository;
       
        public AlbumService(IAlbumsRepository albumsRepository)
        {
            this._albumsRepository = albumsRepository;
        }

        public AlbumModel GetAlbumDetailsByAlbumId(int albumId)
        {           
            return _albumsRepository.GetAlbumDetailsByAlbumId(albumId);
        }
    }
}
