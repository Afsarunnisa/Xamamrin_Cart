using System;

using System.Collections.Generic;


using Newtonsoft.Json;


namespace MyCart.Models
{

	public class StoreResponse
	{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
		public List<Store> data { get; set; }

	}


    public class Store
    {

		[JsonProperty("store_id")]
		public string id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }


		[JsonProperty("store_name")]
		public string store_name { get; set; }

		[JsonProperty("store_language")]
		public string store_language { get; set; }


		[JsonProperty("store_comment")]
		public string store_comment { get; set; }

		[JsonProperty("store_open")]
		public string store_open { get; set; }


		[JsonProperty("store_image")]
		public string store_image { get; set; }

		[JsonProperty("thumb")]
		public string thumb { get; set; }


		[JsonProperty("store_fax")]
		public string store_fax { get; set; }

		[JsonProperty("store_telephone")]
		public string store_telephone { get; set; }


		[JsonProperty("store_email")]
		public string store_email { get; set; }

		[JsonProperty("store_geocode")]
		public string store_geocode { get; set; }


		[JsonProperty("store_address")]
		public string store_address { get; set; }

		[JsonProperty("store_owner")]
		public string store_owner { get; set; }


		[JsonProperty("store_url")]
		public string store_url { get; set; }

		[JsonProperty("config_checkout_guest")]
		public string config_checkout_guest { get; set; }

        public Store()
        {
        }
    }
}
