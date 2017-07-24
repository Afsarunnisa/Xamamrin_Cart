using System;
using System.Collections.Generic;


using Newtonsoft.Json;



namespace MyCart.Models
{

    public class ProductResponse{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
        public List<Products> data { get; set; }

	}
     

    public class Products
    {

		[JsonProperty("id")]
		public string id { get; set; }

		[JsonProperty("seo_h1")]
		public string seo_h1 { get; set; }


		[JsonProperty("name")]
		public string name { get; set; }


		[JsonProperty("manufacturer")]
		public string manufacturer { get; set; }


		[JsonProperty("sku")]
		public string sku { get; set; }

		[JsonProperty("model")]
		public string model { get; set; }

		[JsonProperty("image")]
		public string image { get; set; }


		[JsonProperty("images")]
		public List<string> images { get; set; }

		[JsonProperty("original_image")]
		public string original_image { get; set; }


		[JsonProperty("original_images")]
		public List<string> original_images { get; set; }

		[JsonProperty("price_excluding_tax")]
		public string price_excluding_tax { get; set; }


		[JsonProperty("price")]
		public string price { get; set; }

		[JsonProperty("price_formated")]
		public string price_formated { get; set; }

		[JsonProperty("rating")]
		public string rating { get; set; }

		[JsonProperty("description")]
		public string description { get; set; }

		[JsonProperty("attribute_groups")]
		public AttributeGroups[] attribute_groups { get; set; }


		[JsonProperty("special")]
		public string special { get; set; }

		[JsonProperty("special_excluding_tax")]
		public string special_excluding_tax { get; set; }

		[JsonProperty("special_formated")]
		public string special_formated { get; set; }

		[JsonProperty("special_start_date")]
		public string special_start_date { get; set; }

		[JsonProperty("special_end_date")]
		public string special_end_date { get; set; }

		[JsonProperty("discounts")]
        public Discounts[] discounts { get; set; }

		[JsonProperty("options")]
        public Options[] options { get; set; }


		[JsonProperty("minimum")]
		public string minimum { get; set; }

		[JsonProperty("meta_title")]
		public string meta_title { get; set; }

		[JsonProperty("meta_description")]
		public string meta_description { get; set; }

		[JsonProperty("meta_keyword")]
		public string meta_keyword { get; set; }

		[JsonProperty("tag")]
		public string tag { get; set; }


		[JsonProperty("upc")]
		public string upc { get; set; }

		[JsonProperty("ean")]
		public string ean { get; set; }

		[JsonProperty("jan")]
		public string jan { get; set; }

		[JsonProperty("isbn")]
		public string isbn { get; set; }

		[JsonProperty("mpn")]
		public string mpn { get; set; }





		[JsonProperty("location")]
		public string location { get; set; }


		[JsonProperty("stock_status")]
		public string stock_status { get; set; }

		[JsonProperty("manufacturer_id")]
		public string manufacturer_id { get; set; }

		[JsonProperty("tax_class_id")]
		public string tax_class_id { get; set; }

		[JsonProperty("date_available")]
		public string date_available { get; set; }

		[JsonProperty("weight")]
		public string weight { get; set; }

		[JsonProperty("weight_class_id")]
		public string weight_class_id { get; set; }


		[JsonProperty("length")]
		public string length { get; set; }

		[JsonProperty("width")]
		public string width { get; set; }

		[JsonProperty("height")]
		public string height { get; set; }

		[JsonProperty("length_class_id")]
		public string length_class_id { get; set; }

		[JsonProperty("subtract")]
		public string subtract { get; set; }


		[JsonProperty("sort_order")]
		public string sort_order { get; set; }


		[JsonProperty("status")]
		public string status { get; set; }

		[JsonProperty("date_added")]
		public string date_added { get; set; }

		[JsonProperty("date_modified")]
		public string date_modified { get; set; }

		[JsonProperty("viewed")]
		public string viewed { get; set; }

		[JsonProperty("weight_class")]
		public string weight_class { get; set; }

		[JsonProperty("length_class")]
		public string length_class { get; set; }

		[JsonProperty("reward")]
		public string reward { get; set; }

		[JsonProperty("points")]
		public string points { get; set; }

		[JsonProperty("category")]
		public Category[] category { get; set; }

		[JsonProperty("quantity")]
		public string quantity { get; set; }


		[JsonProperty("reviews")]
        public Reviews reviews { get; set; }

		

		public Products()
        {
        }
    }


    public class AttributeGroups
    {

        [JsonProperty("attribute_group_id")]
        public string attribute_group_id { get; set; }

        [JsonProperty("name")]
        public string name { get; set; }

        [JsonProperty("attribute")]
        public Attribute[] attribute { get; set; }

    }

    public class Attribute{

		[JsonProperty("attribute_id")]
		public string attribute_id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("text")]
		public string text { get; set; }


	}

    public class Discounts
    {

        [JsonProperty("quantity")]
        public string quantity { get; set; }

        [JsonProperty("price_excluding_tax")]
        public string price_excluding_tax { get; set; }

        [JsonProperty("price")]
        public string price { get; set; }

        [JsonProperty("price_formated")]
        public string price_formated { get; set; }
    }

    public class Options{
		
        [JsonProperty("product_option_id")]
		public string product_option_id { get; set; }

		[JsonProperty("option_value")]
		public OptionValues[] option_value { get; set; }

		[JsonProperty("option_id")]
		public string option_id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("type")]
		public string type { get; set; }

		[JsonProperty("value")]
		public string value { get; set; }

		[JsonProperty("required")]
		public string required { get; set; }


	}

	public class OptionValues
	{

		[JsonProperty("image")]
		public string image { get; set; }

		[JsonProperty("price")]
		public string price { get; set; }

		[JsonProperty("price_excluding_tax")]
		public string price_excluding_tax { get; set; }

		[JsonProperty("price_formated")]
		public string price_formated { get; set; }

		[JsonProperty("price_prefix")]
		public string price_prefix { get; set; }

		[JsonProperty("product_option_value_id")]
		public string product_option_value_id { get; set; }

		[JsonProperty("option_value_id")]
		public string option_value_id { get; set; }

		[JsonProperty("name")]
		public string name { get; set; }

		[JsonProperty("quantity")]
		public string quantity { get; set; }

	}

 //   public class Category
	//{

		//[JsonProperty("name")]
		//public string name { get; set; }

		//[JsonProperty("id")]
		//public string id { get; set; }
       
    //}

    public class Reviews{

		[JsonProperty("review_total")]
		public string review_total { get; set; }

	}


}
