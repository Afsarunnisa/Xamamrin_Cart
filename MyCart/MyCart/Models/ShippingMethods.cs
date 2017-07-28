using System;
using System.Collections.Generic;

using Newtonsoft.Json;


namespace MyCart.Models
{
    //public class ShippingMethods
    //{
    //    public ShippingMethods()
    //    {
    //    }

    //}

	public class ShippingMethodsResp
	{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
		public ShippingMethodsData data { get; set; }
	}

	public class ShippingMethodsData
	{

		[JsonProperty("error_warning")]
		public string error_warning { get; set; }


		[JsonProperty("shipping_methods")]
		public Dictionary<string, ShippingMethodsValues> shipping_methods { get; set; }

		[JsonProperty("code")]
		public string code { get; set; }

		[JsonProperty("comment")]
		public string comment { get; set; }


	}

    public class ShippingMethodsValues
	{
		[JsonProperty("title")]
		public string title { get; set; }

		[JsonProperty("quote")]
		public Dictionary<string, ShippingQuoteValues> quote { get; set; }

		[JsonProperty("sort_order")]
		public string sort_order { get; set; }

		[JsonProperty("error")]
		public string error { get; set; }
    }

	public class ShippingQuoteValues
    {

		[JsonProperty("code")]
		public string code { get; set; }

		[JsonProperty("title")]
		public string title { get; set; }

		[JsonProperty("cost")]
		public string cost { get; set; }

		[JsonProperty("tax_class_id")]
		public string tax_class_id { get; set; }

		[JsonProperty("text")]
		public string text { get; set; }

    }


	public class PostShippingMethods
    {
        [JsonProperty("shipping_method")]
        public string shipping_method { get; set; }

        [JsonProperty("comment")]
        public string comment { get; set; }
    }
}