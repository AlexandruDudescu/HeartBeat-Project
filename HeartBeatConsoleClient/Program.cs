using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using HeartBeat_Project.Models;

namespace HeartBeatConsoleClient
{
    class Program
    {
        private static string connectionString;
        private static string portName;

        private static DateTime startTime = DateTime.Now;
        private static TimeSpan spanTime = TimeSpan.FromSeconds(5);

        static void Main(string[] args)
        {
            getData();

            Console.WriteLine("================================================");
            Console.WriteLine("Trying to connect using following data:\nConnection string: {0}\nArduino Bluetooth Com Port: {1}", connectionString, portName);
            Console.WriteLine("================================================");

            while (true)
            {
                while (DateTime.Now < startTime + spanTime) ;
                HeartBeat heartBeat = new HeartBeat(13, DateTime.Now.ToString());
                PostAsync(heartBeat).Wait();
                startTime = DateTime.Now;
            }

        }

        static void getData()
        {
            string[] lines = System.IO.File.ReadAllLines(@"Data.txt");
            connectionString = lines[0];
            portName = lines[1];


        }

        static async Task PostAsync(HeartBeat heartBeat)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(connectionString);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Http post
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/HeartBeat/AddNewHeartBeat", heartBeat);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("HeartBeat Posted succesfully!");
                        PrintPost(heartBeat);
                    }
                    else
                    {
                        Console.WriteLine("Attempt unsuccesfull!\n");

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Attempt unsuccesfull!\n" + ex.Message);
                }
            }

        }

        static void PrintPost(HeartBeat heartBeat)
        {
            Console.WriteLine("Your heart beat rate: {0}\n{1}\n", heartBeat.SampleDate, heartBeat.SampleDate);
        }
    }
}
