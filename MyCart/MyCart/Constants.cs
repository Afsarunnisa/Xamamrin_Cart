﻿using System;
namespace MyCart
{
    public class Constants
    {
		public static string BaseRestUrl = "http://oc.qa.nbos.in/";
		// Basic Y2xpZW50OmNsaWVudA==

		public static string TokenUrl = "http://oc.qa.nbos.in/api/rest/oauth2/token/client_credentials";

		public static string ProductsUrl = "http://oc.qa.nbos.in/api/rest/products/";
		public static string CategoriesUrl = "http://oc.qa.nbos.in/api/rest/categories";


        public static string CartUrl = "http://oc.qa.nbos.in/api/rest/cart";

		public static string StoreUrl = "http://oc.qa.nbos.in/api/rest/stores";

		public static string AddGuestUserUrl = "http://oc.qa.nbos.in/api/rest/guest";
		public static string AddGuestShippingUrl = "http://oc.qa.nbos.in/api/rest/guestshipping";




		public static string ShippingMethodsUrl = "http://oc.qa.nbos.in/api/rest/shippingmethods";
		public static string PaymentMethodsUrl = "http://oc.qa.nbos.in/api/rest/paymentmethods";

		public static string ConfirmUrl = "http://oc.qa.nbos.in/api/rest/confirm";




		public Constants()
        {
        }
    }
}
