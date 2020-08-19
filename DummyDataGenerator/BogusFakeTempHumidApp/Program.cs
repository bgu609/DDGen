using Bogus;
using Newtonsoft.Json;
using System;

namespace BogusFakeTempHumidApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var Rooms = new[] { "Dining Room", "Living Room", "Bath Room", "Bed Room", "Guest Room" };

            var sensorFaker = new Faker<SensorInfo>()
                .RuleFor(o => o.Dev_ID, f => f.PickRandom(Rooms))
                .RuleFor(o => o.Curr_Time, f => f.Date.Past(0).ToString("yyyy-MM-dd HH:mm:ss.ff"))
                .RuleFor(o => o.Temp, f => float.Parse(f.Random.Float(20.0f, 35.9f).ToString("0.00")))
                .RuleFor(o => o.Humid, f => float.Parse(f.Random.Float(40.0f, 63.9f).ToString("0.0")))
                .RuleFor(o => o.Press, f => float.Parse(f.Random.Float(899.0f, 1005.9f).ToString("0.0")));

            var thisValue = sensorFaker.Generate(50);

            Console.WriteLine(JsonConvert.SerializeObject(thisValue, Formatting.None));
            Console.WriteLine();
            Console.WriteLine(JsonConvert.SerializeObject(thisValue, Formatting.Indented));
        }
    }
}
