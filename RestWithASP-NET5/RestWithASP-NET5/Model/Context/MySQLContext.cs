﻿using Microsoft.EntityFrameworkCore;

namespace RestWithASP_NET5.Model.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext() { }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Person> People { get; set; }

        public DbSet<Books> Books { get; set; }
    }
}
