using System;
using Newtonsoft.Json;



namespace MyCart.Models
{

    public class PaymentMethodsResp{

		[JsonProperty("success")]
		public string success { get; set; }

		[JsonProperty("data")]
		public PaymentMethodsData data { get; set; }
    }

    public class PaymentMethodsData{

		[JsonProperty("error_warning")]
		public string error_warning { get; set; }


		[JsonProperty("payment_methods")]
		public PaymentMethods payment_methods { get; set; }
		
        [JsonProperty("code")]
		public string code { get; set; }
		
        [JsonProperty("comment")]
		public string comment { get; set; }

		[JsonProperty("agree")]
		public string agree { get; set; }



	}

    public class PaymentMethods
    {

		[JsonProperty("payment_name")]
		public string payment_name { get; set; }
		
        [JsonProperty("payment_method")]
		public string payment_method { get; set; }


		public PaymentMethods()
        {
        }
    }

	public class PaymentMethodsValues
	{
		public string code { get; set; }
		public string title { get; set; }
		public string terms { get; set; }
		public string sort_order { get; set; }
	}


    public class PostPaymentMethods{
        
        [JsonProperty("payment_method")]
        public string payment_method { get; set; }

		[JsonProperty("agree")]
		public string agree { get; set; }
            
        [JsonProperty("comment")]
        public string comment { get; set; }

    }


}
