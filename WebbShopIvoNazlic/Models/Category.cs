using System.ComponentModel.DataAnnotations;

namespace WebbShopIvoNazlic.Models
{
    public class Category
    {

        /// <summary>
        /// Class for book categories table
        /// </summary>
        /// 
        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"Category: {Name} (id: {Id})";
        }
    }
}
