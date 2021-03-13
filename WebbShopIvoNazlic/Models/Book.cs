using System.ComponentModel.DataAnnotations;

namespace WebbShopIvoNazlic.Models
{
    internal class Book
    {
        /// <summary>
        /// Class for books in table Books
        /// </summary>
        [Key]

        public int ID { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public int Amount { get; set; }

        public int CategoryID { get; set; }

        public override string ToString()
        {
            return $"Book: {Title}({ID}), by {Author}. Price: {Price}, Amount: {Amount}";
        }
    }
}
