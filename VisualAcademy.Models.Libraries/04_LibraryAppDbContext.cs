﻿using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace VisualAcademy.Models.Libraries
{
    /// <summary>
    /// [5] DbContext Class
    /// </summary>
    public class LibraryAppDbContext : DbContext
    {
        // Install-Package Microsoft.EntityFrameworkCore.SqlServer
        // Install-Package Microsoft.EntityFrameworkCore.InMemory
        // Install-Package System.Configuration.ConfigurationManager

        public LibraryAppDbContext()
        {
            // Empty
        }

        public LibraryAppDbContext(DbContextOptions<LibraryAppDbContext> options)
            : base(options)
        {
            // 공식과 같은 코드
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // 닷넷 프레임워크 기반에서 호출되는 코드 영역: 
            // App.config 또는 Web.config의 연결 문자열 사용
            // 직접 데이터베이스 연결문자열 설정 가능
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = ConfigurationManager.ConnectionStrings[
                    "ConnectionString"].ConnectionString;
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryModel>().Property(m => m.Created).HasDefaultValueSql("GetDate()");
        }

        public DbSet<LibraryModel> Libraries { get; set; } = null!;
    }
}
