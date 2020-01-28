using System;
using System.Linq;
using Xunit;
using MusicAlbum;
using MusicAlbum.Model.ModelRec;
using Microsoft.EntityFrameworkCore;
using MusicAlbum.Repository.Repository;
using MusicAlbum.Service.Service;
using Moq;
using MusicAlbum.Repository.Entity;
using System.Collections.Generic;

namespace XUnitTestProject.Unit
{
    public class SongUnitTest
    {
        [Fact]
        public void Task_Get_With_Relation_Return_Equal()
        {
            List<SongResponseModel> obj = new List<SongResponseModel>();
            for (int i = 1; i < 4; i++)
            {
                var songResponse = new SongResponseModel() { SongName = "Test Title " + 1.ToString(), SongDuration = TimeSpan.Parse("00:04:00"), AlbumId = 2, SingerId = i, SongPrice = 3, SongPopularity = i };
                obj.Add(songResponse);
            }
            var songRepository = new Mock<ISongsRepository>();
            songRepository.Setup(x => x.GetSongList(1, 10, 0, string.Empty)).Returns(obj);

            var songService = new SongService(songRepository.Object);
            var result = songService.GetSongList(1, 10, 0, string.Empty);
            Assert.Equal(result.Count, obj.Count);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_NotNull()
        {
            List<SongResponseModel> obj = new List<SongResponseModel>();
            for (int i = 1; i < 4; i++)
            {
                var songResponse = new SongResponseModel() { SongName = "Test Title " + 1.ToString(), SongDuration = TimeSpan.Parse("00:04:00"), AlbumId = 2, SingerId = i, SongPrice = 3, SongPopularity = i };
                obj.Add(songResponse);
            }
            var songRepository = new Mock<ISongsRepository>();
            songRepository.Setup(x => x.GetSongList(1, 10, 0, string.Empty)).Returns(obj);

            var songService = new SongService(songRepository.Object);
            var result = songService.GetSongList(1, 10, 0, string.Empty);
            Assert.NotNull(result);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_Null()
        {
            List<SongResponseModel> obj = new List<SongResponseModel>();
            for (int i = 1; i < 4; i++)
            {
                var songResponse = new SongResponseModel() { SongName = "Test Title " + 1.ToString(), SongDuration = TimeSpan.Parse("00:04:00"), AlbumId = 2, SingerId = i, SongPrice = 3, SongPopularity = i };
                obj.Add(songResponse);
            }
            var songRepository = new Mock<ISongsRepository>();
            songRepository.Setup(x => x.GetSongList(1, 10, 0, string.Empty)).Returns(obj);

            var songService = new SongService(songRepository.Object);
            var result = songService.GetSongList(2, 10, 0, string.Empty);
            Assert.Null(result);
        }
    }
}
