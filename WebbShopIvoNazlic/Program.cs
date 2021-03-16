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
            /// WebbShopAPI.Login("TestCustomer", "Codic2021");
            ///
            ///--------------------------------------------


            /// Logout with test user (Enter test users id)
            ///-------------------------------------------
            ///
            /// WebbShopAPI.Logout();
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


            ///3. List categories containing word "Horror"
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategories("horror"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///4. List all books in category (by id) - (Enter chosen category id))
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategory())
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///5. Show detalis for book (Enter chosen book id)
            ///-------------------------------------------
            ///
            /// Console.WriteLine(WebbShopAPI.GetBook());
            ///
            ///--------------------------------------------


            /// List all books matching keyword "ee"
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetBooks("ee"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            /// List all books by author (i e Stephen King)
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetAuthors("king"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///6. List all available books of certain category (by id) - (enter chosen category id)
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetAvailableBooks())
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            ///7. Buy Book (send parameters userId and bookId)
            ///-------------------------------------------
            /// 
            /// Console.WriteLine(WebbShopAPI.BuyBook(2, 1)); 
            ///
            ///--------------------------------------------


            /// Ping - check if user is online (send parameter userId)
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.Ping());
            /// 
            ///--------------------------------------------           


            /// Register - create new user (send parameters name & password as strings)
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.Register("", ""));
            /// 
            ///--------------------------------------------    


            /// Add Book - add a book to database(send all the parameters)
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.AddBook(1, "Pride and Prejudice", "Jane Austen" , 350, 10));
            /// 
            ///--------------------------------------------  


            /// Set Amount of available books (send parameters userDd and bookId)
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.SetAmount(1, 2));
            /// 
            ///--------------------------------------------  


            /// List all users
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.ListUsers(1))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------



            ///. List all users by keyword
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.FindUser(1, "o"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------



            ///14. Login with Admin user
            ///-------------------------------------------
            ///
            //  WebbShopAPI.Login("Administrator", "CodicRulez");
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
