Welcome to the SkiRateApi,

This Api can be used to give a score on your Skiday aswell as get a avg. score for you season thus far.

This is the following endpoints,

1. List all users,Skilevel,Skibrand GET(./skiers)

2. Create a user POST(./createuser)
   Input example:
   {
	"Name":"Alexander",
	"Level":"ProSkier",
	"Skibrand":"Hendryx"
}

3. Create a skiday POST(./skiday/{name})
   This is where you can create a skiday. It has alot of metrics and calculates a SkidayScore ranging (0-100)
   Input example:
   {
	"location":"Verbier",
	"temperature":-5,
	"airMoisture":60,
	"snowDepth":180,
	"windSpeedMs":2,
	"freshSnow":10,
	"liftQueueTime":1
	
}

Example temperature range: -20 to 30 degrees Celsius
Example air moisture range: 0% to 100%
Example snow depth range: 0 to 200 cm
Example wind speed range: 0 to 14 m/s
Example fresh snow range: 0 to 50 cm
Example lift queue time range: 0 to 60 minutes

Weights for each metric can be ajusted to preference:
double temperatureWeight = 0.2;
double moistureWeight = 0.2;
double snowDepthWeight = 0.1;
double windSpeedWeight = 0.1;
double freshSnowWeight = 0.2;
double liftQueueTimeWeight = 0.2;

4. Get a skiers avg skidayscore for a season GET(./skiers/{name})
   Lists the users name and their avg skidayscore for a season
