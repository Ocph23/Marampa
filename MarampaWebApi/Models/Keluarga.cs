using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace MarampaWebApi.Models
{
    public class Keluarga : Entity
    {
        public string NomorKartuKeluarga { get; set; }

        [NotMapped]
        public Jemaat KepalaKeluarga => Jemaat != null ? Jemaat.SingleOrDefault(x => x.HubunganKeluarga == HubunganKeluarga.KepalaKeluarga) : null;

        public ICollection<Jemaat> Jemaat { get; set; }

        public DateTime Terdaftar { get; set; } = new DateTime();

        [Required]
        public Rayon Rayon { get; set; }

        [Required]
        public string Alamat { get; set; }
        public string Telepon { get; set; }

        public bool Aktif { get; set; } = true;


    }
}