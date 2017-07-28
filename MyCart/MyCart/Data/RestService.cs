using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using MyCart.Models;


namespace MyCart.Data
{
    public class RestService : IRestService
    {
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();

        }

        // Get Oprncart Token
        public async Task GetTokenAsync()
        {

            var url = string.Format(Constants.TokenUrl);
            var uri = new Uri(url);

            try
            {
                client.DefaultRequestHeaders.Add("Authorization", "Basic Y2xpZW50OmNsaWVudA==");

                var response = await client.PostAsync(url, null);
                var content = await response.Content.ReadAsStringAsync();

                Token mytoken = JsonConvert.DeserializeObject<Token>(content);

                App.Current.Properties["AccessToken"] = mytoken.access_token;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"   ERROR {0}", ex.Message);
            }
        }

        public async Task<Boolean> NbosOcConnect(){

			var url = string.Format(Constants.OcConnectUrl);
			var uri = new Uri(url);

            try{

				string nbosToken = "";

				if (App.Current.Properties.ContainsKey("NbosToken"))
				{
					nbosToken = App.Current.Properties["NbosToken"] as string;
				}

				string token = "";

				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                Dictionary<string, string> tokenDict = new Dictionary<string, string>();
                tokenDict.Add("nbos_token", nbosToken);


                var content = new StringContent(JsonConvert.SerializeObject(tokenDict), Encoding.UTF8, "application/json");

				var response = await client.PostAsync(uri, content);

				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@" OC connect  respContent {0}",respContent);

                return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

			return true;

		}




		public async Task<List<Store>> GetAllStores(){
            

			var url = string.Format(Constants.StoreUrl);
			var uri = new Uri(url);


            try{
                
				string token = "";

				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var response = await client.GetAsync(url);
				var content = await response.Content.ReadAsStringAsync();
                StoreResponse resp = JsonConvert.DeserializeObject<StoreResponse>(content);

				return resp.data;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

			return null;
		}


		public async Task<List<Products>> GetAllProducts(string productId, string storeID)
        {

            client.DefaultRequestHeaders.Remove("X-Oc-Store-Id");
			var url = "";

            if(productId == "0"){
                url = string.Format(Constants.ProductsUrl);
            }else{
				var productUrlStr = Constants.ProductsUrl + "category/" + productId;
				url = string.Format(productUrlStr);
			}

            var uri = new Uri(url);

            try
            {
                string token = "";

                if (App.Current.Properties.ContainsKey("AccessToken"))
                {
                    token = App.Current.Properties["AccessToken"] as string;
                }

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //int strIDval = int.Parse(storeID);

                Debug.WriteLine("storeID {0}", storeID);

				client.DefaultRequestHeaders.Add("X-Oc-Store-Id", storeID);


                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                ProductResponse resp = JsonConvert.DeserializeObject<ProductResponse>(content);
                return resp.data;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"   ERROR {0}", ex.Message);
            }

            return null;

        }

        public async Task<List<Category>> GetAllCategories(){

			var url = string.Format(Constants.CategoriesUrl);
			var uri = new Uri(url);

            try{
				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var response = await client.GetAsync(url);
				var content = await response.Content.ReadAsStringAsync();

                CategoryResponse resp = JsonConvert.DeserializeObject<CategoryResponse>(content);

				return resp.data;

            }
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

			return null;

		}


		public async Task<Cart> GetCart(){

			var url = string.Format(Constants.CartUrl);
			var uri = new Uri(url);

            try{

				string token = "";

				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync(uri);
				var respContent = await response.Content.ReadAsStringAsync();

                Cart resp = JsonConvert.DeserializeObject<Cart>(respContent);

                return resp;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}
            return null;

		}


        // Add Product to cart
        public async Task<Boolean> AddToCart(AddCart cart)
        {


            var url = string.Format(Constants.CartUrl);
            var uri = new Uri(url);

            try
            {
                string token = "";

                if (App.Current.Properties.ContainsKey("AccessToken"))
                {
                    token = App.Current.Properties["AccessToken"] as string;
                }


				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                var json = JsonConvert.SerializeObject(cart);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);

                var respContent = await response.Content.ReadAsStringAsync();

                return true;
         	}
            catch (Exception ex)

            {
                Debug.WriteLine(@"   ERROR {0}", ex.Message);
                return false;
			}


        }


		// Add guest user 

        public async Task<Boolean> AddGuestUser(GuestUser user, string url){

			// var url = string.Format(Constants.AddGuestUserUrl);
			var uri = new Uri(url);

            try{
				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				Debug.WriteLine(@"   token {0}", token);

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var json = JsonConvert.SerializeObject(user);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(uri, content);
				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   respContent {0}", respContent);


				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
				return false;
			}

		}




        public async Task<Dictionary<string, PaymentMethodsValues>> GetPaymentMethods()
        {
			var url = string.Format(Constants.PaymentMethodsUrl);
			var uri = new Uri(url);

            try{

				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				Debug.WriteLine(@"   token {0}", token);

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				var response = await client.GetAsync(uri);
				var respContent = await response.Content.ReadAsStringAsync();


				Debug.WriteLine(@"   PaymentMethodsResp {0}", respContent);

				PaymentMethodsResp resp = JsonConvert.DeserializeObject<PaymentMethodsResp>(respContent);


                Debug.WriteLine(@"   PaymentMethodsResp {0}", resp.data.payment_methods);

                Debug.WriteLine(@"   PaymentMethodsResp {0}", resp.data.payment_methods["cod"].code);

                return resp.data.payment_methods;

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

            return null;

		}

        public async Task<Boolean> PostPaymentAddress(Dictionary<string, string> address){

			var url = string.Format(Constants.PostPaymentAddress);
			var uri = new Uri(url);

            try{

				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

                var content = new StringContent(JsonConvert.SerializeObject(address), Encoding.UTF8, "application/json");
				var response = await client.PostAsync(uri, content);
				var respContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(@" OC connect  respContent {0}", respContent);

                return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

			return false;

			
        }




		public async Task<Boolean> SetPaymentMethods(PostPaymentMethods payment){

			var url = string.Format(Constants.PaymentMethodsUrl);
			var uri = new Uri(url);

            try{
				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				var json = JsonConvert.SerializeObject(payment);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(uri, content);
				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   respContent {0}", respContent);

                return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

            return false;

		}


		public async Task<Dictionary<string, ShippingMethodsValues>> GetShippingMethods(){

			var url = string.Format(Constants.ShippingMethodsUrl);
			var uri = new Uri(url);

            try
            {
				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				Debug.WriteLine(@"   token {0}", token);

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
				var response = await client.GetAsync(uri);
				var respContent = await response.Content.ReadAsStringAsync();

                ShippingMethodsResp resp = JsonConvert.DeserializeObject<ShippingMethodsResp>(respContent);


                Debug.WriteLine(@"   PaymentMethodsResp {0}", resp.data.shipping_methods);

                Debug.WriteLine(@"   PaymentMethodsResp {0}", resp.data.shipping_methods["flat"].title);


                Debug.WriteLine(@"   respContent {0}", respContent);

                return resp.data.shipping_methods;


			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

            return null;
        }


        public async Task<Boolean> SetShippingMethods(PostShippingMethods payment)
        {
            var url = string.Format(Constants.ShippingMethodsUrl);
			var uri = new Uri(url);

            try{

				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				var json = JsonConvert.SerializeObject(payment);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await client.PostAsync(uri, content);
				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   respContent {0}", respContent);

				return true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

			return false;



		}

        public async Task<Order> ConfirmCart(){

			var url = string.Format(Constants.ConfirmUrl);
			var uri = new Uri(url);

            try{

				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				//var json = JsonConvert.SerializeObject(payment);
                //var content = new StringContent(null, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, null);
				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   respContent {0}", respContent);

                await this.ConfirmPutCart();
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

            return null;
        }


        public async Task<Boolean> ConfirmPutCart()
        {
			var url = string.Format(Constants.ConfirmUrl);
			var uri = new Uri(url);

            try{

				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

                var response = await client.PutAsync(uri, null);
				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   respContent {0}", respContent);

			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}

            return false;

		}

	}
}