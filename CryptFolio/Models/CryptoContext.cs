using CryptFolio.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptFolio.Models
{
    public class CryptoContext : DbContext
    {
        public DbSet<Currency> Coins { get; set; }

        private static DbContextOptions<CryptoContext> Options { get; set; }
        public static CryptoContext Get {
            get
            {
                return new CryptoContext(Options);
            }
        }

        public CryptoContext(DbContextOptions<CryptoContext> options): base(options)
        {
            Options = options;
        }
    }
}
