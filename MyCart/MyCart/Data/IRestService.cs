using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using MyCart.Models;


namespace MyCart.Data
{
    public interface IRestService
    {

        Task GetTokenAsync();

        Task <List<Products>> GetAllProducts();
        Task<List<Category>> GetAllCategories();


		Task AddToCart(AddCart cart);

        Task <Cart>GetCart();

	}

}
