using System;
using System.ComponentModel.DataAnnotations;

namespace MarampaWebApi.Models
{
    public class Entity
    {

        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;

        [Timestamp]
        public DateTime Updated { get; set; }

        public string Berkas { get; set; }

    }
}