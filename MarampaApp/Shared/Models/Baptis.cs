using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarampaApp.Models
{
    public class Baptis : EntityWithBerkas
    {
        [ForeignKey("Jemaat")]
        public override int Id { get; set; }
        public string NomorSurat { get; set; }

        public string Pendeta { get; set; }
        public string Keterangan { get; set; }

        public string Tempat { get; set; }
        public DateTime Tanggal { get; set; }
        public bool Terverifkasi { get; set; }

        public Jemaat Jemaat { get; set; }

    }
}