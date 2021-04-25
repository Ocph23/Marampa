using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarampaApp.Models
{
    public class EntityWithBerkas:Entity
    {
        public string Berkas { get; set; }

        [NotMapped]
        public byte[] DataBerkas { get; set; }

    }
}