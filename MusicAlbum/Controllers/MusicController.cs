using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicAlbum.Model.ModelRec;
using MusicAlbum.Repository.Entity;
using MusicAlbum.Service.Service;

namespace MusicAlbum.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        #region"Private variables declaration"   
        private readonly ISongService _songService;
        private readonly ISingerService _singerService;
        private readonly IAlbumService _albumService;
        private readonly ILogger<MusicController> _logger;
        #endregion

        #region"Injecting Service and Logger"
        public MusicController(ISongService songService, ISingerService singerService, IAlbumService albumService, ILogger<MusicController> logger)
        {
            this._songService = songService;
            _singerService = singerService;
            _albumService = albumService;
            _logger = logger;
        }
        #endregion

        #region"Main Methods"

        /// <summary>
        /// Returns the Songs List
        /// </summary>
        /// <param name="albumId">entity field</param>
        /// <param name="searchKey">song name</param>
        /// <param name="pageSize">Page Size</param>
        ///  <param name="pageCount">number of songs</param>
        /// <returns>Song List</returns>
        [HttpGet]
        [Route("GetSongList/{albumId}/{pageSize}/{pageCount}")]
        public ActionResult GetSongList(int albumId, int pageSize, int pageCount, [FromQuery]string searchKey = "")
        {
            try
            {
                var result = _songService.GetSongList(albumId, pageSize, pageCount, searchKey);
                if (result.Count <= 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns the Singer Details
        /// </summary>
        /// <param name="id">entity field</param>       
        /// <returns>Singer List</returns>
        [HttpGet]
        [Route("GetSingerDetail/{Id}")]
        public IActionResult GetSingerDetail(int Id)
        {
            try
            {
                var result = _singerService.GetSingerDetailsByAlbumId(Id);
                if (result.Count <= 0)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return BadRequest();
            }
        }

        /// <summary>
        /// Returns the Album Details
        /// </summary>
        /// <param name="albumId">entity field</param>       
        /// <returns>Singer List</returns>
        [HttpGet]
        [Route("GetAlbumDetail/{Id}")]
        public IActionResult GetAlbumDetail(int Id)
        {
            try
            {
                var result = _albumService.GetAlbumDetailsByAlbumId(Id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message.ToString());
                return BadRequest();
            }
        }

        #endregion
    }
}
