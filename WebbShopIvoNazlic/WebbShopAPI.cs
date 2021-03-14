using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebbShopIvoNazlic.Database;
using WebbShopIvoNazlic.Models;

namespace WebbShopIvoNazlic
{
    public static class WebbShopAPI
    {


        private static BookDatabase db = new BookDatabase();


        /* public static void AddBook(string title, string author, int amount, int price, Category [] category)
         {

                 var book = db.Books.FirstOrDefault(b => b.Title == title);

                 if (book == null)
                 {
                     book = db.Books.FirstOrDefault(b => b.Author == author);
                 }

                 if (book == null)
                 {
                     book = new Book { Title = title, Author = author, Amount = amount, Price = price, BookCategory = category };
                 }

         }
        */

        public static void ChangePrice()
        {

            using (var db = new BookDatabase())
            {
                var cabal = db.Books.FirstOrDefault(b => b.Title == "Cabal (Nightbreed)");

                if (cabal != null)

                {
                    cabal.Price = 300;
                }

                db.Update(cabal);
                db.SaveChanges();

            }
        }

        public static void RemoveBook()
        {

            using (var db = new BookDatabase())
            {
                var cabal = db.Books.FirstOrDefault(b => b.Title == "Cabal (Nightbreed)");

                if (cabal != null)

                {
                    db.Books.Remove(cabal);
                }

                db.SaveChanges();

            }
        }

        public static void SortByName()
        {
            using (var db = new BookDatabase())
            {
                foreach (var book in db.Books.OrderBy(b => b.Title))
                {
                    Console.WriteLine(book);
                }
            }

        }

        public static int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);
            if (user != null)
            {
                user.LastLogin = DateTime.Now;
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return user.Id;
            }

            return 0;
        }


        public static void Logout(int id)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == id && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }

        }



    }
}
