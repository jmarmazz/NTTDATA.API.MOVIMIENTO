﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NTTDATA.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext : DbContext
    {
        public QueryContext()
            : base()
        {
        }

        public QueryContext(DbContextOptions<QueryContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost\\SQLEXPRESS;initial catalog=DB_JMARQUEZ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}