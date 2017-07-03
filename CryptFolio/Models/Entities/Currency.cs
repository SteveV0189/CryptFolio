using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptFolio.Models.Entities
{
    public class Currency
    {
        [JsonProperty("db_id")]
        public int Id { get; set; }
        [JsonProperty("id", NullValueHandling=NullValueHandling.Ignore)]
        public string CMC_Id { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Symbol { get; set; }
        [JsonProperty("price_usd")]
        public double? ValueUSD { get; set; }
        [JsonProperty("price_btc")]
        public double? ValueBTC { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int Rank { get; set; }
        [JsonProperty("24h_volume_usd")]
        public double? Volume { get; set; }
        [JsonProperty("market_cap_usd")]
        public double? MarketCap { get; set; }
        [JsonProperty("percent_change_1h")]
        public double? Change_1Hr { get; set; }
        [JsonProperty("percent_change_24h")]
        public double? Change_24Hr { get; set; }
        [JsonProperty("percent_change_7d")]
        public double? Change_7D { get; set; }
        [JsonProperty("last_updated", NullValueHandling = NullValueHandling.Ignore)]
        public string LastUpdated { get; set; }
    }
}
