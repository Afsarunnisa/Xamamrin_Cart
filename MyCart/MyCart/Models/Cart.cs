using System;
using Newtonsoft.Json;

namespace MyCart.Models
{
    public class Cart
    {
		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
        public CartData data { get; set; }

    }

    public class CartData{

		[JsonProperty("error_warning")]
		public string error_warning { get; set; }

		[JsonProperty("attention")]
		public string attention { get; set; }

		[JsonProperty("weight")]
		public string weight { get; set; }

		[JsonProperty("products")]
		public CartProducts[] products { get; set; }

		[JsonProperty("vouchers")]
		public CartVouchers[] vouchers { get; set; }

		[JsonProperty("coupon_status")]
		public string coupon_status { get; set; }

		[JsonProperty("coupon")]
		public string coupon { get; set; }

		[JsonProperty("voucher_status")]
		public string voucher_status { get; set; }


		[JsonProperty("voucher")]
		public string voucher { get; set; }

		[JsonProperty("reward_status")]
		public string reward_status { get; set; }

		[JsonProperty("reward")]
		public string reward { get; set; }

		[JsonProperty("totals")]
		public CartTotal[] totals { get; set; }


		[JsonProperty("total")]
		public string total { get; set; }

		[JsonProperty("total_product_count")]
		public string total_product_count { get; set; }


		
		
	}

    public class CartProducts{
		[JsonProperty("key")]
		public string key { get; set; }

		[JsonProperty("thumb")]
		public string thumb { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("product_id")]
		public string product_id { get; set; }

		[JsonProperty("model")]
		public string model { get; set; }

		[JsonProperty("weight")]
		public string weight { get; set; }

		[JsonProperty("option")]
		public CartOption[] option { get; set; }


		[JsonProperty("quantity")]
		public string quantity { get; set; }

		[JsonProperty("stock")]
		public string stock { get; set; }

		[JsonProperty("reward")]
		public string reward { get; set; }

		[JsonProperty("price")]
		public string price { get; set; }


		[JsonProperty("total")]
		public string total { get; set; }


      
	}

    public class CartOption{

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("value")]
		public string value { get; set; }
    }

	public class CartVouchers
	{
        [JsonProperty("name")]
		public string name { get; set; }
	}


    public class CartTotal{
		[JsonProperty("title")]
		public string title { get; set; }

		[JsonProperty("text")]
		public string text { get; set; }


	}

	public class AddCart
	{
		public string product_id { get; set; }
		public string quantity { get; set; }
	}


}
