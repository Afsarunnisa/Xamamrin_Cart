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

        public Task<List<Products>> GetProducts(string productId, string storeID){

            return restService.GetAllProducts(productId, storeID);

		}

        public Task<List<Category>> GetCategories()
		{
            return restService.GetAllCategories();
		}


        public Task<Boolean> AddToCart(AddCart cart){
            return restService.AddToCart(cart);
        }

        public Task<Cart> GetCart()
        {
            return restService.GetCart();
		}

        public Task<List<Store>> GetStores()
		{
            return restService.GetAllStores();
		}


        public Task<Boolean> AddGuestUser(GuestUser user)
		{
            return restService.AddGuestUser(user, Constants.AddGuestUserUrl);
		}

		public Task<Boolean> AddGuestShipping(GuestUser user)
		{
            return restService.AddGuestUser(user, Constants.AddGuestShippingUrl);
		}



		public Task<Dictionary<string, ShippingMethodsValues>> GetShippingMethods()
		{
            return restService.GetShippingMethods();
		}


        public Task<Boolean> SetShippingMethod(PostShippingMethods shippng)
		{
            return restService.SetShippingMethods(shippng);
		}


		public Task<Dictionary<string, PaymentMethodsValues>> GetPaymentMethods(){
            return restService.GetPaymentMethods();
        }


        public Task<Boolean> SetPaymentMethod(PostPaymentMethods payment){
            return restService.SetPaymentMethods(payment);

        }

		public Task<Order> ConfirmCart()
		{
            return restService.ConfirmCart();

		}

        public Task<Boolean> OcConnect(){
            return restService.NbosOcConnect();
        }

         
        public Task<Boolean> PostPaymentAddress(Dictionary<string, string> address){
            return restService.PostPaymentAddress(address);
        }

	}
}