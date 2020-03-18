using System;
using System.Collections.Generic;
using System.Text;
using Database.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        /// <summary/>
        public DatabaseContext(DbContextOptions options) : base(options)
        { }

        /// <summary>
        /// Станции
        /// </summary>
        public virtual DbSet<Station> Stations { get; set; }

        /// <summary>
        /// Пользователи
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        /// <summary>
        /// Пути
        /// </summary>
        public virtual DbSet<Passage> Passages { get; set; }

        /// <summary>
        /// Поезда
        /// </summary>
        public virtual DbSet<Train> Trains { get; set; }
    }
}
