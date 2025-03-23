using oopassign2;
using TextFile;

namespace oopassign2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TextFileReader reader = new TextFileReader("C:\\Users\\Waseer\\OneDrive\\Desktop\\Assignment2-Final\\oopassign2\\input.txt");

                reader.ReadLine(out string line); int n = int.Parse(line);
                List<Area> areas = new();

                for (int i = 0; i < n; i++)
                {
                    char[] separators = new char[] { ' ', '\t' };
                    Area area = null;

                    if (reader.ReadLine(out line))
                    {
                        string[] tokens = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                        string name = tokens[0] + " " + tokens[1];
                        char a = char.Parse(tokens[2]);
                        int w = int.Parse(tokens[3]);

                        switch (a)
                        {
                            case 'P': area = new plain(name, w); break;
                            case 'G': area = new grassLand(name, w); break;
                            case 'L': area = new lakes(name, w); break;
                        }
                    }

                    areas.Add(area);
                }

                reader.ReadInt(out int humidity);

                //Before
                Console.WriteLine("Before: ");
                for (int i = 0; i < areas.Count; i++)
                {
                    areas[i].setHumidity(humidity);
                    Console.WriteLine(areas[i].ToString());
                }

                int round = 1;
                string maxLandLord = "";
                double maxWaterStored = double.MinValue;
                Iweather weather = Sunny.Instance();
                Console.WriteLine("\nSimulation Starting\n");
                while (round <= 10)
                {
                    Console.WriteLine("\n" + "Round: " + round);
                    for (int i = 0; i < areas.Count; i++)
                    {
                        areas[i].modifyHumidity();
                        weather = areas[i].updateWeather();
                        areas[i].weather_affect_area(weather);
                        int hum = areas[i].humidity;
                        areas[i] = areas[i].modifyArea();
                        areas[i].humidity = hum;
                        Console.WriteLine(areas[i].ToString());
                        if (areas[i].getWater() > maxWaterStored)
                        {
                            maxWaterStored = areas[i].getWater();
                            maxLandLord = areas[i].getName();
                        }
                    }
                    round++;
                }

                Console.WriteLine("\n\nmaximum amount of water stored by the owner is: " + maxLandLord);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File is not there");
            }

        }
    }
}