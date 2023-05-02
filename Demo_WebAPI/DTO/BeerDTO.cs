namespace Demo_WebAPI.DTO
{
    public class BeerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        public int? CreateDate { get; set; }
        public double Degree { get; set; }
        public string? Brewery { get; set; }
    }

    public class BeerDataDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;
        public int? CreateDate { get; set; }
        public double Degree { get; set; }
        public string? Brewery { get; set; }
    }
}
