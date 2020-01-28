using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Repository
{
    public class SongsRepository : ISongsRepository
    {
        #region"Calling Context private method"
        private readonly MusicAlbumContext _context = null;
        public SongsRepository(MusicAlbumContext context)
        {
            _context = context;
        }
        #endregion

        public List<SongResponseModel> GetSongList(int albumId, int pageSize, int pageCount, string searchKey)
        {
            var result = (from s in _context.Songs
                          join sg in _context.Singers on s.SingerId equals sg.SingerId
                          join a in _context.Albums on s.AlbumId equals a.AlbumId
                          where a.AlbumId == albumId && a.IsActive == true && s.IsActive == true
                          && sg.IsActive == true
                          select new SongResponseModel
                          {
                              SingerName = sg.SingerName,
                              SingerId = sg.SingerId,
                              SongDuration = s.SongDuration,
                              SongName = s.SongName,
                              SongPrice = s.SongPrice,
                              AlbumId = a.AlbumId,
                              AlbumName = a.AlbumName,
                              SongPopularity = s.SongPopularity
                          }).AsQueryable();

            return result.Where(x => x.SongName.Contains(searchKey)).Skip(pageCount * pageSize).Take(pageSize).ToList();
        }
    }
}
