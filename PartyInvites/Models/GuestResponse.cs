
using System.ComponentModel.DataAnnotations;
namespace PartyInvites.Models
{
    public class GuestResponse
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+")]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public bool? WillAttend { get; set; } 
    }
}
