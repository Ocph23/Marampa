using System;
using System.ComponentModel.DataAnnotations;

namespace MarampaApp.Models
{
    public class Entity
    {

        [Key]
        public virtual int Id { get; set; }
        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }

        public string Berkas { get; set; }

    }
}