namespace SkiRateApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public string Skibrand { get; set; }

        public virtual ICollection<Skiday> Skidays { get; set; }
    }
}
