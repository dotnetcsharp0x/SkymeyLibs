﻿using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using SkymeyLibs.Models.Tables.Posts;
using SkymeyLibs.Models.Tables.Tokens;

namespace SkymeyLibs.Data
{
    public class ApplicationMongoContext : DbContext
    {
        public DbSet<API_POST> API_POST { get; init; }
        public DbSet<API_POST_TAGS> API_POST_TAGS { get; init; }
        public DbSet<API_POST_RESPONSES> API_POST_RESPONSES { get; init; }
        public DbSet<API_POST_PARAMS> API_POST_PARAMS { get; init; }
        public DbSet<API_POST_CODE_SAMPLES> API_POST_CODE_SAMPLES { get; init; }
        public DbSet<API_TOKEN> API_TOKEN { get; init; }
        public DbSet<CurrentPrices> CurrentPrices { get; init; }
        public static ApplicationMongoContext Create(IMongoDatabase database) =>
            new(new DbContextOptionsBuilder<ApplicationMongoContext>()
                .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
                .Options);
        public ApplicationMongoContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<API_POST>().ToCollection("API_POST");
            modelBuilder.Entity<API_POST_TAGS>().ToCollection("API_POST_TAGS");
            modelBuilder.Entity<API_POST_RESPONSES>().ToCollection("API_POST_RESPONSES");
            modelBuilder.Entity<API_POST_PARAMS>().ToCollection("API_POST_PARAMS");
            modelBuilder.Entity<API_POST_CODE_SAMPLES>().ToCollection("API_POST_CODE_SAMPLES");
            modelBuilder.Entity<API_TOKEN>().ToCollection("crypto_tokens");
            modelBuilder.Entity<CurrentPrices>().ToCollection("crypto_current_prices");
        }
    }
}
