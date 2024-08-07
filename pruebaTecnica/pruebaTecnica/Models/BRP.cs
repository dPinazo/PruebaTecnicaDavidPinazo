namespace pruebaTecnica.Models
{
    public class BRP
    {
        public int Id { get; set; }
        public string BrpCode { get; set; }
        public string BrpName { get; set; }
        public string BusinessId { get; set; }
        public string CodingScheme { get; set; }
        public string Country { get; set; }
        public DateTime ValidityStart { get; set; }
        public DateTime ValidityEnd { get; set; }
    }
}
