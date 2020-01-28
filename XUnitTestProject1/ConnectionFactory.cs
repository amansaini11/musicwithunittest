using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using MusicAlbum.Repository.Context;
using System;
using System.IO;
namespace XUnitTestProject.Unit
{
    public class ConnectionFactory : IDisposable
    {
        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  
        public MusicAlbumContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<MusicAlbumContext>().UseInMemoryDatabase(databaseName: "MusicAlbum").Options;
            var context = new MusicAlbumContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
            return context;
        }

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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
