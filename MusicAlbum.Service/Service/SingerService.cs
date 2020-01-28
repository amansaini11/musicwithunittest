using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicAlbum.Service.Service
{
   public class SingerService: ISingerService
    {
        private readonly ISingersRepository _singersRepository;

        public SingerService(ISingersRepository singersRepository)
        {
            this._singersRepository = singersRepository;
        }

        public List<SingerModel> GetSingerDetailsByAlbumId(int albumId)
        {          
            return _singersRepository.GetSingerDetailsByAlbumId(albumId);
        }
    }
}
