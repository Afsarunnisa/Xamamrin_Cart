using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MyCart.Models
{
    public class Category
    {
		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("id")]
		public string id { get; set; }




		public Category()
        {
        }
    }
}
