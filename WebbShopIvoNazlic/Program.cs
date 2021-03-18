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

            /// Add all the mock data to the database
            ///-------------------------------------------
            ///
            ///  MockData.AddData();
            ///
            ///--------------------------------------------


            /// Login with test user
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


            /// List categories containing word "Horror"
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategories("horror"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            /// List all books in category (by id) - (Enter chosen category id))
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetCategory())
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            /// Show detalis for book (Enter chosen book id)
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


            /// List all available books of certain category (by id) - (enter chosen category id)
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.GetAvailableBooks())
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            /// Buy Book (send parameters userId and bookId)
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


            /// List all users by keyword
            ///-------------------------------------------
            ///
            /// foreach (var item in WebbShopAPI.FindUser(1, "o"))
            /// {
            /// Console.WriteLine(item);
            /// }
            ///
            ///--------------------------------------------


            /// Update Book - update book data
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.UpdateBook(1, 3, "Testing testing", "Madeup Author" , 350));
            /// 
            ///--------------------------------------------  


            /// Delete Book - Reduce amount by one, delete when amount is zero
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.DeleteBook(1, 3));
            /// 
            ///--------------------------------------------  


            /// Add Category
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.AddCategory(1, "Biography"));
            /// 
            ///--------------------------------------------  


            /// Add Book to category
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.AddBookToCategory(1, 5, 5));
            /// 
            ///--------------------------------------------  
            ///


            /// Update category
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.UpdateCategory(1, 5, "Romance"));
            /// 
            ///--------------------------------------------  
            ///


            /// Delete Category if no book is linked to it
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.DeleteCategory(1, 5));
            /// 
            ///--------------------------------------------  



            /// Add user - create new user if user doesnt exist and password is not ""
            ///------------------------------------------- 
            /// 
            /// Console.WriteLine(WebbShopAPI.AddUser(1, "Pest", "Kolera"));
            /// 
            ///--------------------------------------------    


            /// Login with Admin user
            ///-------------------------------------------
            ///
            ///  WebbShopAPI.Login("Administrator", "CodicRulez");
            ///
            ///--------------------------------------------


        }


    }
}
