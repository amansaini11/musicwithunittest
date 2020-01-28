using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MusicAlbum.Repository.Context;
using System;
using System.IO;
namespace XUnitTestProject.Unit
{
    public class ConnectionFactory
    {      
        public MusicAlbumContext CreateContextForSQLite()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var option = new DbContextOptionsBuilder<MusicAlbumContext>().UseSqlite(connection).Options;
            var context = new MusicAlbumContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            return context;
        }
    }
}
