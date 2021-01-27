namespace MarampaWebApi.Models
{
    public class Gereja : Entity
    {
        public string Sinode { get; set; }
        public string Klasis { get; set; }
        public string Nama { get; set; }
        public string Alamat { get; set; }
        public string Telepon { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public TahunPelayanan TahunPelayanan { get; set; }

    }
}