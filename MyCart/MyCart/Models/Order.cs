using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MyCart.Models
{

	public class Order
	{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
		public OrdersData data { get; set; }

	}

	public class OrderStatus
	{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("order_id")]
		public string order_id { get; set; }

	}

	public class OrdersData
	{
		[JsonProperty("order_id")]
		public string order_id { get; set; }

		[JsonProperty("products")]
		public List<OrderProducts> products { get; set; }

		[JsonProperty("vouchers")]
		public List<ProductVouchers> vouchers { get; set; }

		[JsonProperty("totals")]
		public List<ProductTotal> totals { get; set; }

		[JsonProperty("payment")]
		public string payment { get; set; }

	}

	public class OrderProducts
	{
		[JsonProperty("key")]
		public string key { get; set; }

		[JsonProperty("product_id")]
		public string product_id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }


		[JsonProperty("model")]
		public string model { get; set; }


		[JsonProperty("option")]
		public List<ProductOption> option { get; set; }

		[JsonProperty("recurring")]
		public string recurring { get; set; }

		[JsonProperty("quantity")]
		public string quantity { get; set; }

		[JsonProperty("subtract")]
		public string subtract { get; set; }

		[JsonProperty("price")]
		public string price { get; set; }

		[JsonProperty("total")]
		public string total { get; set; }

		[JsonProperty("href")]
		public string href { get; set; }

	}


}
