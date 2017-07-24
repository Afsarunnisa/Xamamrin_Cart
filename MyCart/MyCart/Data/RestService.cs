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

        public async Task GetTokenAsync()
        {

            var url = string.Format(Constants.TokenUrl);
            var uri = new Uri(url);

            Debug.WriteLine(@"   url {0}", url);


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


        public async Task<List<Products>> GetAllProducts()
        {

            var url = string.Format(Constants.ProductsUrl);
            var uri = new Uri(url);

            Debug.WriteLine(@"   url {0}", url);
            try
            {
                string token = "";

                if (App.Current.Properties.ContainsKey("AccessToken"))
                {
                    token = App.Current.Properties["AccessToken"] as string;
                }

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync(url);
                var content = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(@"   content string {0}", content);

                ProductResponse resp = JsonConvert.DeserializeObject<ProductResponse>(content);

                Debug.WriteLine(@"   content {0}", content);

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

			Debug.WriteLine(@"   url {0}", url);

            try{
				string token = "";
				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var response = await client.GetAsync(url);
				var content = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   content string {0}", content);

				//C resp = JsonConvert.DeserializeObject<ProductResponse>(content);

				//Debug.WriteLine(@"   content {0}", content);
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

			Debug.WriteLine(@"   url {0}", url);

            try{

				string token = "";

				if (App.Current.Properties.ContainsKey("AccessToken"))
				{
					token = App.Current.Properties["AccessToken"] as string;
				}

				Debug.WriteLine(@"   Token {0}", token);

				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var response = await client.GetAsync(uri);

				var respContent = await response.Content.ReadAsStringAsync();

				Debug.WriteLine(@"   content string {0}", respContent);

                Cart resp = JsonConvert.DeserializeObject<Cart>(respContent);

				Debug.WriteLine(@"   resp {0}", resp);
                Debug.WriteLine(@"   resp {0}", resp.data.total);
                Debug.WriteLine(@"   resp {0}", resp.data.totals);

                return resp;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(@"   ERROR {0}", ex.Message);
			}
            return null;

		}


		public async Task AddToCart(AddCart cart)
        {


            var url = string.Format(Constants.CartUrl);
            var uri = new Uri(url);

            Debug.WriteLine(@"   url {0}", url);

            try
            {
                string token = "";

                if (App.Current.Properties.ContainsKey("AccessToken"))
                {
                    token = App.Current.Properties["AccessToken"] as string;
                }

                Debug.WriteLine(@"   Token {0}", token);


				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);


                var json = JsonConvert.SerializeObject(cart);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(uri, content);

                var respContent = await response.Content.ReadAsStringAsync();

                Debug.WriteLine(@"   content string {0}", respContent);

				Debug.WriteLine(@"   content string {0}", respContent);


			}
            catch (Exception ex)

            {
                Debug.WriteLine(@"   ERROR {0}", ex.Message);
            }


        }
    }
}