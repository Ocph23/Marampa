using System.ComponentModel.DataAnnotations;

namespace MarampaApp.Models
{
    public class Gereja : Entity
    {
        [Required]
        public string Sinode { get; set; }
        [Required]
        public string Klasis { get; set; }

        [Required]
        public string Nama { get; set; }
        [Required]
        public string Alamat { get; set; }
        [Required]
        public string Telepon { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Tidak Valid !")]
        public string Email { get; set; }
        public string Website { get; set; }

    }
}