using Microsoft.EntityFrameworkCore;
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

        public static int Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password && u.IsActive);
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

        public static void Logout(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                user.SessionTimer = DateTime.MinValue;
                db.Users.Update(user);
                db.SaveChanges();
            }

        }

        public static List<Category> GetCategories()
        {
            return db.BookCategories.ToList();
        }

        public static List<Category> GetCategories(string keyword)
        {
            List<Category> listOfCategories = new List<Category>();

            foreach (var category in db.BookCategories.Where(n => n.Name.ToLower().Contains(keyword.ToLower())))
            {
                if (category != null)
                {
                    listOfCategories.Add(category);
                }
            }

            return listOfCategories;
        }

        public static List<Book> GetCategory(int id)
        {
            List<Book> booksOfCategory = new List<Book>();

            foreach (var book in db.Books.Where(bc => bc.BookCategory.Id == id))
            {
                if (book != null)
                {
                    booksOfCategory.Add(book);
                }
            }

            return booksOfCategory;
        }

        public static List<Book> GetAvailableBooks(int id)
        {
            List<Book> availableBooks = new List<Book>();

            foreach (var book in db.Books.Where(b => b.Amount > 0 && b.BookCategory.Id == id))
            {
                if (book != null)
                {
                    availableBooks.Add(book);
                }
            }
            return availableBooks;
        }

        public static Book GetBook(int id)
        {
            var book = (db.Books.FirstOrDefault(b => b.Id == id));

            if (book != null)
            {
                return book;
            }
            return book;

        }

        public static List<Book> GetBooks(string keyword)
        {
            List<Book> matchingBooks = new List<Book>();

            foreach (var book in db.Books.Where(n => n.Title.ToLower().Contains(keyword.ToLower())))
            {
                if (book != null)
                {
                    matchingBooks.Add(book);
                }
            }

            return matchingBooks;
        }

        public static List<Book> GetAuthors(string keyword)
        {
            List<Book> booksByAuthor = new List<Book>();

            foreach (var book in db.Books.Where(n => n.Author.ToLower().Contains(keyword.ToLower())))
            {
                if (book != null)
                {
                    booksByAuthor.Add(book);
                }
            }

            return booksByAuthor;
        }

        public static bool BuyBook(int userId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId);
            var book = db.Books.Include(b => b.BookCategory).FirstOrDefault(b => b.Id == bookId);

            if (user != null && user.SessionTimer > DateTime.Now.AddMinutes(-15) && user.IsActive)
            {
                if (book.Amount > 0)
                {
                    book.Amount -= 1;
                    db.Books.Update(book);
                    db.SoldBooks.Add(new SoldBook
                    {
                        Title = book.Title,
                        Author = book.Author,
                        CategoryId = book.BookCategory.Name,
                        Price = book.Price,
                        PurchasedDate = DateTime.Now,
                        Users = user
                    });

                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public static string Ping(int userId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == userId && u.SessionTimer > DateTime.Now.AddMinutes(-15));
            if (user != null)
            {
                return "pong";
            }

            return string.Empty;

        }

        public static bool Register(string name, string password)
        {
            var user = db.Users.FirstOrDefault(u => u.Name == name && u.Password == password);
            if (user == null)
            {
                Console.Write("Please comfirm password: ");
                string input = Console.ReadLine();
                if (password == input)
                {
                    db.Users.Add(new User { Name = name, Password = password });
                    db.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public static bool AddBook(int adminId, string title, string author, int price, int amount)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var book = db.Books.FirstOrDefault(b => b.Title == title && b.Author == author);
            if (user != null)
            {
                if (book == null)
                {
                    db.Books.Add(new Book
                    {
                        Title = title,
                        Author = author,
                        Amount = amount,
                        Price = price,
                    });
                }
                else
                {
                    book.Amount = amount;
                    db.Books.Update(book);
                }
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public static bool SetAmount(int adminId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (user != null && book != null)
            {
                Console.Write("Set amount of available books: ");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    book.Amount = input;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
                catch (System.FormatException)
                {
                    return false;
                }
            }
            return false;
        }

        public static List<User> ListUsers(int adminId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            if (user != null)
            {
                return db.Users.ToList();
            }
            List<User> noData = new List<User>();
            return noData;
        }

        public static List<User> FindUser(int adminId, string keyword)
        {
            var loggedUser = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            List<User> usersByKeyword = new List<User>();

            if (loggedUser != null)
            {
                foreach (var user in db.Users.Where(u => u.Name.ToLower().Contains(keyword.ToLower())))
                {
                    usersByKeyword.Add(user);
                }
            }
            return usersByKeyword;
        }

        public static bool UpdateBook(int adminId, int id, string title, string author, int price)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (user != null)
            {
                if (book != null)
                {
                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    db.Books.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool DeleteBook(int adminId, int bookId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            if (user != null && book != null)
            {
                if (book.Amount > 1)
                {
                    book.Amount -= 1;
                    db.Books.Update(book);
                }
                else
                {
                    db.Books.Remove(book);
                }
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public static bool AddCategory(int adminId, string name)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var category = db.BookCategories.FirstOrDefault(c => c.Name == name);

            if (user != null && category == null)
            {
                db.BookCategories.Add(new Category { Name = name });
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var book = db.Books.FirstOrDefault(b => b.Id == bookId);
            var category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (user != null && book != null && category != null)
            {
                book.BookCategory = category;
                db.Books.Update(book);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool UpdateCategory(int adminId, int categoryId, string name)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (user != null && category != null)
            {
                category.Name = name;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteCategory(int adminId, int categoryId)
        {
            var user = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var category = db.BookCategories.FirstOrDefault(c => c.Id == categoryId);

            if (user != null && category != null && GetCategory(category.Id).Count == 0)
            {
                db.BookCategories.Remove(category);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool AddUser(int adminId, string name, string password)
        {
            if (String.IsNullOrEmpty(password))
            {
                return false;
            }

            var loggedUser = db.Users.FirstOrDefault(u => u.Id == adminId && u.SessionTimer > DateTime.Now.AddMinutes(-15) && u.IsAdmin);
            var user = db.Users.FirstOrDefault(u => u.Name == name);

            if (loggedUser != null && user == null)
            {
                    db.Users.Add(new User { Name = name, Password = password });
                    db.SaveChanges();
                    return true;
            }

            return false;
        }

    }
}
