using System.ComponentModel.DataAnnotations;

namespace Charity.Mvc.Models.Selects
{
    public class UserSelect2
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Hało jest wymagane")]
        public string Password { get; set; }
    }
}
