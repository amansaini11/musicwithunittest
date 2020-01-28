using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Repository
{
    public class SingersRepository : ISingersRepository
    {
        #region"Calling Context private method"
        private readonly MusicAlbumContext _context = null;
        public SingersRepository(MusicAlbumContext context)
        {
            _context = context;
        }
        #endregion

        public List<SingerModel> GetSingerDetailsByAlbumId(int albumId)
        {
            var result = (from s in _context.Singers
                          join sa in _context.SingerAlbumLinks on s.SingerId equals sa.SingerId
                          join a in _context.Albums on sa.AlbumId equals a.AlbumId
                          where a.AlbumId == albumId && a.IsActive == true && s.IsActive == true
                          && s.IsActive == true
                          select new SingerModel
                          {
                              SingerId = s.SingerId,
                              SingerName = s.SingerName,
                              SingerReview = s.SingerReview,
                              AlbumId = a.AlbumId,
                              AlbumName = a.AlbumName
                          }).AsQueryable();
            return result.ToList();
        }

    }
}
