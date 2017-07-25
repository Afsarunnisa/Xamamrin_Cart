using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyCart.Models;


namespace MyCart.Data
{
    public interface IRestService
    {

        Task GetTokenAsync();

		Task<List<Store>> GetAllStores();
		//Task<Store> GetStore();


		Task <List<Products>> GetAllProducts(string productId, string storeID);
        Task<List<Category>> GetAllCategories();


        Task<Boolean> AddToCart(AddCart cart);
        Task <Cart>GetCart();

        Task<Boolean> AddGuestUser(GuestUser user);


        Task <List<PaymentMethods>> GetPaymentMethods();
        Task<Boolean> SetPaymentMethods(PostPaymentMethods payment);



	}
}