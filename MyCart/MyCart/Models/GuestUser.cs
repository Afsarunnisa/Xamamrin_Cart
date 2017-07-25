using System;
using MyCart.Models;

using Newtonsoft.Json;


namespace MyCart.Models
{
    public class GuestUser
    {

		[JsonProperty("address_1")]
		public string address_1 { get; set; }

		[JsonProperty("address_2")]
		public string address_2 { get; set; }

		[JsonProperty("city")]
		public string city { get; set; }

		[JsonProperty("company_id")]
		public string company_id { get; set; }

		[JsonProperty("company")]
		public string company { get; set; }

		[JsonProperty("country_id")]
		public string country_id { get; set; }

		[JsonProperty("email")]
		public string email { get; set; }

		[JsonProperty("fax")]
		public string fax { get; set; }

		[JsonProperty("firstname")]
		public string firstname { get; set; }

		[JsonProperty("lastname")]
		public string lastname { get; set; }

		[JsonProperty("postcode")]
		public string postcode { get; set; }

		[JsonProperty("tax_id")]
		public string tax_id { get; set; }

		[JsonProperty("telephone")]
		public string telephone { get; set; }

		[JsonProperty("zone_id")]
		public string zone_id { get; set; }


        public GuestUser()
        {
        }
    }
}
