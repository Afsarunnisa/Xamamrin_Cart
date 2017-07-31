using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyCart.Models;


namespace MyCart.Data
{
    public interface IRestService
    {

        Task<Boolean> GetTokenAsync();

		Task<List<Store>> GetAllStores();

		Task <List<Products>> GetAllProducts(string productId, string storeID);
        Task<List<Category>> GetAllCategories();

        Task<List<FeaturedProducts>> GetFeaturedProducts();


        Task<Boolean> AddToCart(AddCart cart);
        Task <Cart>GetCart();

        Task<Boolean> AddGuestUser(GuestUser user, string url);


        Task<Dictionary<string, ShippingMethodsValues>> GetShippingMethods();
        Task<Boolean> SetShippingMethods(PostShippingMethods shipping);


        Task<Dictionary<string, PaymentMethodsValues>> GetPaymentMethods();
		Task<Boolean> SetPaymentMethods(PostPaymentMethods payment);


        Task<Order> ConfirmCart();
        Task<Boolean> ConfirmPutCart();

		Task<Boolean> NbosOcConnect();

        Task<Boolean> PostPaymentAddress(Dictionary<string, string> postAddress);


		//Task<Order> ConfirmCart();

	}
}