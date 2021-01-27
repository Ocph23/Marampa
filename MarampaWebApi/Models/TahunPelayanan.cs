using System;

namespace MarampaWebApi.Models
{
    public class TahunPelayanan : Entity
    {
        public DateTime Mulai { get; set; }
        public DateTime Sampai { get; set; }
        public bool Aktif { get; set; }
    }
}