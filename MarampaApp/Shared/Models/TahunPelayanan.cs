using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MarampaApp.Models
{
    public class TahunPelayanan : Entity
    {
        public string Tahun => $"{Mulai.Year}/{Sampai.Year}";

        [Required]
        public DateTime Mulai { get; set; }
        [Required]
        public DateTime Sampai { get; set; }
        public bool Aktif { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Sampai < Mulai)
            {
                yield return new ValidationResult(
                    errorMessage: "Tanggal Samapai Harus Lebih Besar Dari Tanggal Mulai",
                    memberNames: new[] { "Sampai" }
               );
            }
        }
    }
}