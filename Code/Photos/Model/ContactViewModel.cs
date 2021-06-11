using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Photos.Model
{
    public class ContactViewModel
    {
        //Dirty way of adding the fa icon on error
        [Required(ErrorMessage = "<i class=\"fas fa-exclamation-triangle\"></i> Name is required")]
        [MinLength(5, ErrorMessage = "<i class=\"fas fa-exclamation-triangle\"></i> Minimum Length 5")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public bool FailMail { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}