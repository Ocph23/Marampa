using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarampaWebApi.Models
{
    public class Nikah
    {
        [ForeignKey("Jemaat")]
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [Timestamp]
        public DateTime Updated { get; set; }

        public string Berkas { get; set; }
        public string NomorSurat { get; set; }
        public string Pasangan { get; set; }
        public DateTime TanggalMenikah { get; set; }
        public string Tempat { get; set; }
        public string Pendeta { get; set; }
        public string Keterangan { get; set; }
        public Jemaat Jemaat { get; set; }
        public bool Disini { get; set; }
        public bool Terverifkasi { get; set; }

    }
}