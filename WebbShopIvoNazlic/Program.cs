using System;
using System.Collections.Generic;
using System.Linq;
using WebbShopIvoNazlic.Database;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic
{
    class Program
    {
        static void Main(string[] args)
        {

            ///1. Adding all the mock data to the database
            ///-------------------------------------------
            ///
            ///  MockData.AddData();
            ///
            ///--------------------------------------------


            ///2. Login with test user
            ///-------------------------------------------
            ///
            ///  WebbShopAPI.Login("TestCustomer", "TestCustomer");
            ///
            ///--------------------------------------------


            ///3. List categories containing word "Horror"
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategories("horror"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            /// List all categories
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategories())
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------
            ///


            ///4. List all books in category (by ID) - (id 1 = horror)
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategory(1))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///5. Show detalis for book Dr Sleep (id 2)
            ///-------------------------------------------
            ///
            /// Console.WriteLine(WebbShopAPI.GetBook(2));
            ///
            ///--------------------------------------------


            /// List all boos matching keyword "ee"
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetBooks("ee"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///6. List all available books (by ID) - (id 1 = horror)
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetAvailableBooks(1))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///14. Login with Admin user
            ///-------------------------------------------
            ///
            ///  WebbShopAPI.Login("Administrator", "CodicRulez");
            ///
            ///--------------------------------------------





            //Console.WriteLine(WebbShopAPI.Login("Administrator", "CodicRulez"));
            //WebbShopAPI.Logout(1);


            //AddMockData();
            //WebbShopAPI WebShop = new WebbShopAPI();

            //AddBook("Ivos Book", "Moi", 1500, 1, category(Horror));
            //SortByName();
            //ChangePrice();
            //RemoveBook();

        }



    }
}
