using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaSoftAPI.Models.Order
{
    public class Dates
    {
        [JsonProperty("fromDate")]
        public string FromDate { get; set; }

        [JsonProperty("toDate")]
        public string ToDate { get; set; }
    }

    public class Region
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

    }

    public class Address
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("subway")]
        public string Subway { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("apartment")]
        public string Apartment { get; set; }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }
    }

    public class Delivery
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }

        [JsonProperty("deliveryServiceId")]
        public int DeliveryServiceId { get; set; }

        [JsonProperty("deliveryPartnerType")]
        public string DeliveryPartnerType { get; set; }

        [JsonProperty("dates")]
        public Dates Dates { get; set; }

        [JsonProperty("region")]
        public Region Region { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }
    }

    public class Buyer
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("uid")]
        public int Uid { get; set; }
    }

    public class Item
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("feedId")]
        public int FeedId { get; set; }

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("feedCategoryId")]
        public string FeedCategoryId { get; set; }

        [JsonProperty("offerName")]
        public string OfferName { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }

        [JsonProperty("buyer-price")]
        public int BuyerPrice { get; set; }

        [JsonProperty("subsidy")]
        public int Subsidy { get; set; }

        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("params")]
        public string Params { get; set; }

        [JsonProperty("vat")]
        public string Vat { get; set; }

        [JsonProperty("fulfilmentShopId")]
        public int FulfilmentShopId { get; set; }

        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("warehouseId")]
        public int WarehouseId { get; set; }

        [JsonProperty("partnerWarehouseId")]
        public string PartnerWarehouseId { get; set; }
    }

    public class Order
    {
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("businessId")]
        public int BusinessId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fake")]
        public bool Fake { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("creationDate")]
        public string CreationDate { get; set; }

        [JsonProperty("itemsTotal")]
        public int ItemsTotal { get; set; }

        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("subsidyTotal")]
        public int SubsidyTotal { get; set; }

        [JsonProperty("totalWithSubsidy")]
        public int TotalWithSubsidy { get; set; }

        [JsonProperty("taxSystem")]
        public string TaxSystem { get; set; }

        [JsonProperty("delivery")]
        public Delivery Delivery { get; set; }

        [JsonProperty("buyer")]
        public Buyer Buyer { get; set; }

        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }

    public class Root
    {
        [JsonProperty("order")]
        public Order Order { get; set; }
    }
}
