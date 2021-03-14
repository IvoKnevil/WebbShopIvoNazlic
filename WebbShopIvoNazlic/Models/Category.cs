using System.ComponentModel.DataAnnotations;

namespace WebbShopIvoNazlic.Models
{
    internal class Category
    {

        /// <summary>
        /// Class for book categories table
        /// </summary>
        /// 
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
