namespace YourITMatch.Models
{
    public class CompanyModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public string NIP { get; set; }
        public string Regon { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public string Street { get; set; }
        public int CompanySize { get; set; }
        public DateOnly CompanyEstablished { get; set; }
        public string CompanyWebsite { get; set; }
    }
}