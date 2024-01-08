namespace SkiRateApi.Models.DTO
{
    
    public class CreateSkidayDTO
    {
        public string location { get; set; }
        public double temperature { get; set; }
        public double airMoisture { get; set; }
        public double snowDepth { get; set; }
        public double windSpeedMs { get; set; }
        public double freshSnow { get; set; }
        public double liftQueueTime { get; set; }
    }
}
