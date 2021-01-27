using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarampaWebApi.Models
{
    public class Sidi
    {
        [ForeignKey("Jemaat")]
        public int Id { get; set; }
        public string NomorSurat { get; set; }

        public string Pendeta { get; set; }
        public string Keterangan { get; set; }
        public string Tempat { get; set; }
        public DateTime Tanggal { get; set; }

        public Jemaat Jemaat { get; set; }

        public bool Terverifkasi { get; set; }

    }
}