using System.ComponentModel.DataAnnotations;

namespace MarampaApp.Models
{
    public class PejabatGereja : Entity
    {

        [Required]
        public Jemaat Jemaat { get; set; }

        [Required]
        public TahunPelayanan TahunPelayanan { get; set; }

        public Rayon Rayon { get; set; }

        [Required]
        public Jabatan Jabatan { get; set; }

    }
}