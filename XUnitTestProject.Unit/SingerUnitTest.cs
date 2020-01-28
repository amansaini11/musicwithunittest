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
    public class SingerUnitTest
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
                var singerAlbum = new SingerAlbumLinks()
                {
                    SingerAlbumId = i,
                    SingerId = i,
                    AlbumId = 2,
                };
                context.SingerAlbumLinks.Add(singerAlbum);
            }
            context.SaveChanges();

            var singerRepo = new SingersRepository(context);
            var singerService = new SingerService(singerRepo);
            var result = singerService.GetSingerDetailsByAlbumId(2);
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
                var singerAlbum = new SingerAlbumLinks()
                {
                    SingerAlbumId = i,
                    SingerId = i,
                    AlbumId = 2,
                };
                context.SingerAlbumLinks.Add(singerAlbum);
            }
            context.SaveChanges();

            var singerRepo = new SingersRepository(context);
            var singerService = new SingerService(singerRepo);
            var result = singerService.GetSingerDetailsByAlbumId(2);
            Assert.NotNull(result);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_NotEqual()
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
                var singerAlbum = new SingerAlbumLinks()
                {
                    SingerAlbumId = i,
                    SingerId = i,
                    AlbumId = 2,
                };
                context.SingerAlbumLinks.Add(singerAlbum);
            }
            context.SaveChanges();

            var singerRepo = new SingersRepository(context);
            var singerService = new SingerService(singerRepo);

            var result = singerService.GetSingerDetailsByAlbumId(4);
            Assert.NotEqual(3, result.Count);
        }
    }
}
