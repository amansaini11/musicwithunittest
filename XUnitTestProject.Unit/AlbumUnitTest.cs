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
    public class AlbumUnitTest
    {
        [Fact]
        public void Task_Get_With_Relation_Return_Equal()
        {
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();

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
                var albumRating = new AlbumRating()
                {
                    AlbumRatingId = i,
                    AlbumId = 2,
                    AlbumRatingBy = i,
                    AlbumRatings = i,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.AlbumRating.Add(albumRating);
            }
            context.SaveChanges();

            var albumsRepo = new AlbumsRepository(context);
            var albumsService = new AlbumService(albumsRepo);

            var result = albumsService.GetAlbumDetailsByAlbumId(2);
            Assert.Equal(2, result.AlbumId);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_NotNull()
        {
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();

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
                var albumRating = new AlbumRating()
                {
                    AlbumRatingId = i,
                    AlbumId = 2,
                    AlbumRatingBy = i,
                    AlbumRatings = i,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.AlbumRating.Add(albumRating);
            }
            context.SaveChanges();

            var albumsRepo = new AlbumsRepository(context);
            var albumsService = new AlbumService(albumsRepo);

            var result = albumsService.GetAlbumDetailsByAlbumId(2);
            Assert.NotNull(result);
        }

        [Fact]
        public void Task_Get_With_Relation_Return_Null()
        {
            var factory = new ConnectionFactory();
            var context = factory.CreateContextForSQLite();
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
                var albumRating = new AlbumRating()
                {
                    AlbumRatingId = i,
                    AlbumId = 2,
                    AlbumRatingBy = i,
                    AlbumRatings = i,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    CreatedBy = 1,
                    ModifiedBy = 1
                };
                context.AlbumRating.Add(albumRating);
            }
            context.SaveChanges();

            var albumsRepo = new AlbumsRepository(context);
            var albumsService = new AlbumService(albumsRepo);

            var result = albumsService.GetAlbumDetailsByAlbumId(5);
            Assert.Null(result);
        }
    }
}
