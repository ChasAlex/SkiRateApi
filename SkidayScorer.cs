namespace SkiRateApi
{
    public static class SkidayScorer
    {
        public static int CalculateSkiDayScore(double temperature, double airMoisture, double snowDepth, double windSpeedMs, double freshSnow, double liftQueueTime)
        {
            // Define weights for each metric
            double temperatureWeight = 0.2;
            double moistureWeight = 0.2;
            double snowDepthWeight = 0.1;
            double windSpeedWeight = 0.1;
            double freshSnowWeight = 0.2;
            double liftQueueTimeWeight = 0.2;

            // Normalize the metrics to a 0-100 scale
            double normalizedTemperature = NormalizeMetric(temperature, -20, 30); // Example temperature range: -20 to 30 degrees Celsius
            double normalizedMoisture = NormalizeMetric(airMoisture, 0, 100); // Example air moisture range: 0% to 100%
            double normalizedSnowDepth = NormalizeMetric(snowDepth, 0, 200); // Example snow depth range: 0 to 200 cm
            double normalizedWindSpeed = NormalizeMetric(windSpeedMs, 0, 14); // Example wind speed range: 0 to 14 m/s
            double normalizedFreshSnow = NormalizeMetric(freshSnow, 0, 50); // Example fresh snow range: 0 to 50 cm
            double normalizedLiftQueueTime = NormalizeMetric(liftQueueTime, 0, 60); // Example lift queue time range: 0 to 60 minutes

            // Calculate the weighted average score
            double score = (temperatureWeight * normalizedTemperature +
                            moistureWeight * (100 - normalizedMoisture) + // Inverse relationship: lower moisture is better
                            snowDepthWeight * normalizedSnowDepth +
                            windSpeedWeight * (100 - normalizedWindSpeed) + // Inverse relationship: lower wind speed is better
                            freshSnowWeight * normalizedFreshSnow +
                            liftQueueTimeWeight * (100 - normalizedLiftQueueTime)) /
                           (temperatureWeight + moistureWeight + snowDepthWeight + windSpeedWeight + freshSnowWeight + liftQueueTimeWeight);

            // Ensure the score is within the 0-100 range
            score = Math.Max(0, Math.Min(100, score));
            int score_to_int = Convert.ToInt32(score);

            
            return score_to_int;
        }

        private static double NormalizeMetric(double value, double minValue, double maxValue)
        {
            // Normalize the metric to a 0-100 scale
            return Math.Max(0, Math.Min(100, (value - minValue) / (maxValue - minValue) * 100));
        }














    }
}
