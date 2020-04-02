using KTaseva.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KTaseva.Data
{
    public class KTasevaDbContext : IdentityDbContext<User>
    {
        public KTasevaDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
