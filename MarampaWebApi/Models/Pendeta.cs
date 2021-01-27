using System;

namespace MarampaWebApi.Models
{
    public class Pendeta : Jemaat
    {
        public DateTime Mulai { get; set; }
        public DateTime Selesai { get; set; }
        public string AsalGereja { get; set; }
        public string Keterangan { get; set; }
        public bool Aktif { get; set; } = true;
    }
}