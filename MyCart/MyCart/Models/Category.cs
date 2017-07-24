using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace MyCart.Models
{

	public class CategoryResponse
	{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
        public List<Category> data { get; set; }

	}

	//  public class Category
	//  {
	//[JsonProperty("name")]
	//public string name { get; set; }

	//[JsonProperty("id")]
	//public string id { get; set; }


	//}

	public class Category
	{

		[JsonProperty("id")]
		public string id { get; set; }

		[JsonProperty("category_id")]
		public string category_id { get; set; }



		[JsonProperty("parent_id")]
		public string parent_id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }
		
        [JsonProperty("image")]
		public string image { get; set; }

		[JsonProperty("original_image")]
		public string original_image { get; set; }

		[JsonProperty("categories")]
		public string categories { get; set; }

		


	}
}
