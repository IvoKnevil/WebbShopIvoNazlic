using System.ComponentModel.DataAnnotations;

namespace WebbShopIvoNazlic.Models
{
    class User
    {

        [Key]

        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int LastLogin { get; set; }

        public int SessionTimer { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        public override string ToString()
        {
            return $"User: {Name}({Id}), pass: {Password}, LastLogin: {LastLogin}, SessionTimer: {SessionTimer}";
        }



    }
}
