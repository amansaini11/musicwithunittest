using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Service.Service
{
   public class SongService:ISongService
    {
        private readonly ISongsRepository _songsRepository;

        public SongService(ISongsRepository songsRepository)
        {
            this._songsRepository = songsRepository;

        }
        public List<SongResponseModel> GetSongList(int albumId, int pageSize, int pageCount, string searchKey)
        {
            List<SongResponseModel> songResponseModels = new List<SongResponseModel>();
            return _songsRepository.GetSongList(albumId, pageSize, pageCount, searchKey);
        }
    }
}
