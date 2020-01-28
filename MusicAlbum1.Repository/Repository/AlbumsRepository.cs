using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Repository.Repository
{
    public class AlbumsRepository : IAlbumsRepository
    {
        #region"Calling Context private method"
        private readonly MusicAlbumContext _context = null;
        public AlbumsRepository(MusicAlbumContext context)
        {
            _context = context;
        }
        #endregion
       
        public AlbumModel GetAlbumDetailsByAlbumId(int albumId)
        {
            var result = (from a in _context.Albums                        
                          join ar in _context.AlbumRating on a.AlbumId equals ar.AlbumId
                          where a.AlbumId == albumId && a.IsActive == true  && ar.IsActive==true
                          select new AlbumModel
                          {
                              AlbumId = a.AlbumId,
                              AlbumImagePath = a.AlbumImagPath,
                              AlbumName = a.AlbumName,
                              AlbumPrice = a.AlbumPrice,
                              AlbumReleaseDate = a.AlbumReleaseDate,   
                              //AlbumRatings = GetAlbumRating(a.AlbumId),
                              AlbumRatingId =ar.AlbumRatingId
                          }).FirstOrDefault();

            var resultRating = (from a in _context.AlbumRating
                          where a.AlbumId == albumId && a.IsActive == true
                          select new
                          {
                              AlbumRatings = a.AlbumRatings,
                          }).ToList();
            int total = resultRating.ToList().Sum(p => p.AlbumRatings);
            if (result != null) {
                result.AlbumRatings = (100 / ((resultRating.Count * 10) / total));
            }
            return result;
        }

        private int GetAlbumRating(int albumId)
        {
            var result = (from a in _context.AlbumRating 
                          where a.AlbumId == albumId && a.IsActive == true 
                          select new {
                              AlbumRatings = a.AlbumRatings,
                          }).ToList();
            int total = result.ToList().Sum(p => p.AlbumRatings);
            return ((total * (result.Count * 10)) / 100);
        }
    }

}
