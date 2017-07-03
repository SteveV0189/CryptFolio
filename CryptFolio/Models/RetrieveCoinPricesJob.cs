using CryptFolio.Models.Entities;
using FluentScheduler;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CryptFolio.Models
{
    public class RetrieveCoinPricesJob : IJob
    {
        private const string COINBASE_API = "https://api.coinmarketcap.com/v1/ticker/";

        public void Execute()
        {
            ExecuteAync().Wait();
        }

        public async Task ExecuteAync()
        {
            try
            {
                var http = new System.Net.Http.HttpClient();
                var msg = await http.GetAsync(COINBASE_API);
                var content = await msg.Content.ReadAsStringAsync();
                var coins = JsonConvert.DeserializeObject<List<Currency>>(content);
                using (var ctx = CryptoContext.Get)
                {
                    ctx.ChangeTracker.AutoDetectChangesEnabled = false;
                    await ctx.Database.ExecuteSqlCommandAsync("DELETE FROM Coins");
                    if (ctx.Coins.Any(c => c.Id > 2000))
                    {
                        await ctx.Database.ExecuteSqlCommandAsync("DELETE FROM SQLITE_SEQUENCE WHERE NAME = 'Coins';");
                    }
                    await ctx.Coins.AddRangeAsync(coins);
                    await ctx.SaveChangesAsync();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
