using System.ComponentModel.DataAnnotations;

namespace Charity.Mvc.Models.Selects
{
    public class UserSelect1
    {
        public string Login
        {
            get { return this.Email; }
            set { this.Email = value; }
        }

        [Required(ErrorMessage = "Imię jest wymagane")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-mail jest wymagane")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Powtórzenie hasła jest wymagane")]
        [Compare("Password", ErrorMessage = "Hasła nie są identyczne")]
        public string RepeatPassword { get; set; }
    }
}
