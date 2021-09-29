using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaSoftAPI.Models.Stocks.Response
{
    public class Item
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }

    public class Sku
    {
        [JsonProperty("sku")]
        public string sku { get; set; }

        [JsonProperty("warehouseId")]
        public int WarehouseId { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Root
    {
        [JsonProperty("skus")]
        public List<Sku> Skus { get; set; }
    }
}
