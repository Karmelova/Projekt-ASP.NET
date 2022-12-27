namespace YourITMatch.Models
{
    public class CompanyAddressModel
    {
        public int ID { get; set; }
        public int CompanyID { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Voivodeship { get; set; }
        public string Street { get; set; }
    }
}