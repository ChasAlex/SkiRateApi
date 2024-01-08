namespace SkiRateApi.Models
{
    public class Skiday
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int Score { get; set; }

        public virtual User user { get; set; }
    }
}
