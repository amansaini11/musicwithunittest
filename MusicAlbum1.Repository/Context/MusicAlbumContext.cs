using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicAlbum.Repository.Entity;
namespace MusicAlbum.Repository.Context
{
    public class MusicAlbumContext : DbContext
    {
        public MusicAlbumContext(DbContextOptions<MusicAlbumContext> options) : base(options)
        {
        }
        public DbSet<Singers> Singers { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<AlbumRating> AlbumRating { get; set; }
        public DbSet<Albums> Albums { get; set; }
        public DbSet<SingerAlbumLinks> SingerAlbumLinks { get; set; }
       
    }
}


    