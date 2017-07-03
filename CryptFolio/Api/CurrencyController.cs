using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CryptFolio.Models;
using CryptFolio.Models.Entities;

namespace CryptFolio.Api
{
    [Produces("application/json")]
    [Route("api/Currency")]
    public class CurrencyController : Controller
    {
        public CryptoContext ctx { get; private set; }

        public CurrencyController(CryptoContext ctx)
        {
            this.ctx = ctx;
        }

        [Route("")]
        public IActionResult GetAllCurrencies()
        {
            return new OkObjectResult(ctx.Coins.ToList());
        }

        [Route("GetNames")]
        public IActionResult GetNames()
        {
            return new OkObjectResult(ctx.Coins.Select(c => c.Name).ToList());
        }

        [Route("FromSymbol/{name}")]
        public IActionResult GetCurrencyByTokenName(string name)
        {
            return new OkObjectResult(ctx.Coins.FirstOrDefault<Currency>(c => c.Symbol == name));
        }

        [Route("FromName/{name}")]
        public IActionResult GetCurrencyByCurrencyName(string name)
        {
            return new OkObjectResult(ctx.Coins.FirstOrDefault<Currency>(c => c.Name == name));
        }

        [Route("OrderBy/Volume")]
        public IActionResult GetCurrenciesByVolume([FromQuery]string method = "descending")
        {
            if (method == "descending")
            {
                return new OkObjectResult(ctx.Coins.OrderByDescending(c => c.Volume).ToList());
            }
            return new OkObjectResult(ctx.Coins.OrderBy(c => c.Volume).ToList());
        }

        [Route("OrderBy/Rank")]
        public IActionResult GetCurrenciesByRank([FromQuery]string method = "descending")
        {
            if (method == "descending")
            {
                return new OkObjectResult(ctx.Coins.OrderByDescending(c => c.Rank).ToList());
            }
            return new OkObjectResult(ctx.Coins.OrderBy(c => c.Rank).ToList());
        }

        [Route("OrderBy/Change")]
        public IActionResult GetCurrenciesByPercentChange([FromQuery]string method = "descending", [FromQuery]string time = "1h")
        {
            if (method == "descending")
            {
                switch(time)
                {
                    case "1h":
                        return new OkObjectResult(ctx.Coins.OrderByDescending(c => c.Change_1Hr).ToList());
                    case "24h":
                        return new OkObjectResult(ctx.Coins.OrderByDescending(c => c.Change_24Hr).ToList());
                    case "7d":
                        return new OkObjectResult(ctx.Coins.OrderByDescending(c => c.Change_7D).ToList());
                }
            }
            switch(time)
            {
                case "1h":
                    return new OkObjectResult(ctx.Coins.OrderBy(c => c.Change_1Hr).ToList());
                case "24h":
                    return new OkObjectResult(ctx.Coins.OrderBy(c => c.Change_24Hr).ToList());
                case "7d":
                    return new OkObjectResult(ctx.Coins.OrderBy(c => c.Change_7D).ToList());
            }
            //This *should* never happen. Ever.
            return new OkObjectResult(ctx.Coins.OrderByDescending(c => c.Change_1Hr).ToList());
        }
    }
}