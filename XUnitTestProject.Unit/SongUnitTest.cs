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
using MusicAlbum.Repository.Context;

namespace XUnitTestProject.Unit
{
    public class SongUnitTest
    {
        [Fact]
        public void Task_Get_With_Relation_Return_Equal()
        {
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();

            for (int i = 1; i < 4; i++)
            {
                var singers = new Singers()
                {
                    SingerId = i,
                    SingerName = "Category " + i,
                    SingerReview = "good one",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Singers.Add(singers);
            }

            for (int i = 1; i < 4; i++)
            {
                var album = new Albums()
                {
                    AlbumId = i,
                    AlbumName = "Category " + i,
                    AlbumImagPath = "../Test/Image.png",
                    AlbumPrice = 1,
                    AlbumReleaseDate = DateTime.Now,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Albums.Add(album);
            }

            for (int i = 1; i < 4; i++)
            {
                var songs = new Songs()
                {
                    SongId = i,
                    SingerId = 2,
                    AlbumId = 2,
                    SongDuration = TimeSpan.Parse("00:04:00"),
                    SongName = "Test Song" + i.ToString(),
                    SongPrice = 3,
                    SongPopularity = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Songs.Add(songs);
            }
            context.SaveChanges();

            var songRepo = new SongsRepository(context);
            var songService = new SongService(songRepo);
            var result = songService.GetSongList(2, 10, 0, string.Empty);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_NotNull()
        {
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();

            for (int i = 1; i < 4; i++)
            {
                var singers = new Singers()
                {
                    SingerId = i,
                    SingerName = "Category " + i,
                    SingerReview = "good one",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Singers.Add(singers);
            }

            for (int i = 1; i < 4; i++)
            {
                var album = new Albums()
                {
                    AlbumId = i,
                    AlbumName = "Category " + i,
                    AlbumImagPath = "../Test/Image.png",
                    AlbumPrice = 1,
                    AlbumReleaseDate = DateTime.Now,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Albums.Add(album);
            }

            for (int i = 1; i < 4; i++)
            {
                var songs = new Songs()
                {
                    SongId = i,
                    SingerId = 2,
                    AlbumId = 2,
                    SongDuration = TimeSpan.Parse("00:04:00"),
                    SongName = "Test Song" + i.ToString(),
                    SongPrice = 3,
                    SongPopularity = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Songs.Add(songs);
            }
            context.SaveChanges();

            var songRepo = new SongsRepository(context);
            var songService = new SongService(songRepo);
            var result = songService.GetSongList(2, 10, 0, string.Empty);
            Assert.NotNull(result);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_Null()
        {
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();

            for (int i = 1; i < 4; i++)
            {
                var singers = new Singers()
                {
                    SingerId = i,
                    SingerName = "Category " + i,
                    SingerReview = "good one",
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Singers.Add(singers);
            }

            for (int i = 1; i < 4; i++)
            {
                var album = new Albums()
                {
                    AlbumId = i,
                    AlbumName = "Category " + i,
                    AlbumImagPath = "../Test/Image.png",
                    AlbumPrice = 1,
                    AlbumReleaseDate = DateTime.Now,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Albums.Add(album);
            }

            for (int i = 1; i < 4; i++)
            {
                var songs = new Songs()
                {
                    SongId = i,
                    SingerId = 2,
                    AlbumId = 2,
                    SongDuration = TimeSpan.Parse("00:04:00"),
                    SongName = "Test Song" + i.ToString(),
                    SongPrice = 3,
                    SongPopularity = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.Songs.Add(songs);
            }

            var songRepo = new SongsRepository(context);
            var songService = new SongService(songRepo);
            var result = songService.GetSongList(5, 10, 0, string.Empty);
            Assert.Equal(0, result.Count);
        }
    }
}
