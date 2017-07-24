using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyCart.Models;


namespace MyCart.Data
{
    public class ApiManager
    {
		IRestService restService;


		public ApiManager(IRestService service)
        {
			restService = service;
		}

		public Task GetToken()
		{
            return restService.GetTokenAsync();
		}

        public Task<List<Products>> GetProducts(string productId){

            return restService.GetAllProducts(productId);

		}

        public Task<List<Category>> GetCategories()
		{
            return restService.GetAllCategories();
		}


        public Task AddToCart(AddCart cart){
            return restService.AddToCart(cart);
        }

        public Task<Cart> GetCart()
        {
            return restService.GetCart();
		}


	}
}
