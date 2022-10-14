using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace LitecartLoginTest
{
    public class Products
    {

        public string Photo { get; set; } = System.AppDomain.CurrentDomain.BaseDirectory + @"test.jpg";
        public string Status { get; set; } = "Enabled";
        public string Name { get; set; } = "TP"+ DateTime.Now.ToString("yyMMddmmss");
        public string Code { get; set; } = "TestCode";
        public string Categories{ get; set; } = "Subcategory";
        public string Gender { get; set; } = "Unisex";
        public string Quantity { get; set; } = "100";
        public string QuantityUnit { get; set; } = "pcs";
        public string DeliveryStatus { get; set; } = "3-5 days";
        public string SoldOutStatus { get; set; } = "Sold out";
        public string DateValidFrom { get; set; } = "20.01.2022";
        public string DateValidTo { get; set; } = "20.09.2022";
        public string Manufacturer { get; set; } = "ACME Corp.";
        public string Supplier { get; set; } = "-- Select --";
        public string Keywords { get; set; } = "Keywords";
        public string ShortDescription{ get; set; } = "ShortDescription";
        public string Description { get; set; } = "Description";
        public string HeadTitle { get; set; } = "HeadTitle";
        public string MetaDescription { get; set; } = "MetaDescription";
        public string PurchasePrice { get; set; } = "15";
        public string PurchasePriceCurrency { get; set; } = "US Dollars";
        public string PriceUSD { get; set; } = "10";
        public string PriceEUR { get; set; } = "11";
        public string PriceInclUSD { get; set; } = "11";
        public string PriceInclEUR { get; set; } = "12";

        public Products()
        {

        }

    }
}
