﻿using Microsoft.EntityFrameworkCore;
using Thunders.CRUD.Domain.Clients;

namespace Thunders.CRUD.infrastructure
{
    public class ThunderContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public ThunderContext(DbContextOptions<ThunderContext> options) : base(options)
        {
        }
    }
}