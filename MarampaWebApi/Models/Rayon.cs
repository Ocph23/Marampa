using System.ComponentModel.DataAnnotations.Schema;

namespace MarampaWebApi.Models
{
    public class Rayon : Entity
    {
        public string Nama { get; set; }
        public string Deskripsi { get; set; }

        [ForeignKey("KetuaId")]
        public Jemaat Ketua { get; set; }
        [ForeignKey("SekertarisId")]
        public Jemaat Sekertaris { get; set; }
        [ForeignKey("BendaharaId")]
        public Jemaat Bendahara { get; set; }
    }
}