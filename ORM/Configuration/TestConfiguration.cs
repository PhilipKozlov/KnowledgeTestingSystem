﻿using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    /// <summary>
    /// Represents Test entity configuration when mapping to database schema.
    /// </summary>
    public class TestConfiguration : EntityTypeConfiguration<Test>
    {
        /// <summary>
        /// Configures Test entity.
        /// </summary>
        public TestConfiguration()
        {
            HasKey(p => p.Id);
            Property(p => p.Name).IsRequired().HasMaxLength(100);
            Property(p => p.Created).HasColumnType("datetime2").IsRequired();
            Property(p => p.IsTimed).IsRequired();
        }
    }
}
