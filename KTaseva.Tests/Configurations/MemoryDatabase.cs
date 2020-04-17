using KTaseva.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace KTaseva.Tests.Configurations
{
    public static class MemoryDatabase
    {
        public static DbContextOptions<KTasevaDbContext> OptionBuilder()
        {
            return new DbContextOptionsBuilder<KTasevaDbContext>()
                  .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
        }
    }
}
