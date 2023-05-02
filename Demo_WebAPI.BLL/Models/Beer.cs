namespace Demo_WebAPI.BLL.Models
{
    public class Beer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Variety { get; set; }
        public int? CreateDate { get; set; }
        public double Degree { get; set; }
        public string? Brewery { get; set; }

        public Beer(int id, string name, string variety, int? createDate, double degree, string? brewery)
        {
            Id = id;
            Name = name;
            Variety = variety;
            CreateDate = createDate;
            Degree = degree;
            Brewery = brewery;
        }
    }
}
