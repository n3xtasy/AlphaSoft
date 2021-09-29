using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaSoftAPI.Models.Stocks.Request
{
    public class Root
    {
        [JsonProperty("warehouseId")]
        public int WarehouseId { get; set; }

        [JsonProperty("skus")]
        public List<string> Skus { get; set; }
    }
}
