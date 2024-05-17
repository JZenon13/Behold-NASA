using System;
namespace NASA_BE;
class Program
{
    static void Main()
    {
        string roverPhotoDates = "./api/dates.txt";
        string[] dates = File.ReadAllLines(roverPhotoDates);


        if (File.Exists(roverPhotoDates))
        {
            try
            {
                foreach (string date in dates)
                {
                    Console.WriteLine(date);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
