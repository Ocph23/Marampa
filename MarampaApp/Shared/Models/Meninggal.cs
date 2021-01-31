using System;

namespace MarampaApp.Models
{
    public class Meninggal : Entity
    {
        public string NomorSurat { get; set; }
        public string Keterangan { get; set; }
        public string Tempat { get; set; }
        public DateTime Tanggal { get; set; }
        public Jemaat Jemaat { get; set; }
    }
}