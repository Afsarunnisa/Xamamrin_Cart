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
    }
}