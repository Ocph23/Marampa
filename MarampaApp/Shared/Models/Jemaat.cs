using System;
using System.ComponentModel.DataAnnotations;

namespace MarampaApp.Models
{
    public class Jemaat : Entity
    {

        public string NIK { get; set; }

        [Required(ErrorMessage = "Nama Tidak Boleh Kosong")]
        public string Nama { get; set; }
        public JenisKelamin JenisKelamin { get; set; }

        [Required(ErrorMessage = "Tanggal Lahir Tidak Boleh Kosong")]
        public DateTime? TanggalLahir { get; set; }

        public HubunganKeluarga HubunganKeluarga { get; set; }

        public StatusJemaat StatusJemaat { get; set; }

        public bool StatusPernikahan { get; set; }


        public string Kawin => StatusPernikahan ? "Kawin" : "Belum";
        public int Umur=> TanggalLahir==null ? 0: DateTime.Now.Year-TanggalLahir.Value.Year;


        public Nikah Nikah { get; set; }
        public Baptis Baptis { get; set; }
        public Sidi Sidi { get; set; }
        public Pekerjaan Pekerjaan { get; set; }
         public Keluarga Keluarga { get; set; }


    }
}