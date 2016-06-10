using HeartBeat_Project.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeartBeatClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static DateTime startTime = DateTime.Now;
        private static TimeSpan spanTime = TimeSpan.FromSeconds(5);

        private void button1_Click(object sender, EventArgs e)
        {
            Program.canContinue = true;
            while (Program.canContinue)
            {
                while (DateTime.Now < startTime + spanTime) ;
                HeartBeat heartBeat = new HeartBeat(45, DateTime.Now.ToString());
                PostAsync(heartBeat).Wait();
                startTime = DateTime.Now;
            }
        }

        async Task PostAsync(HeartBeat heartBeat)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri(textBox2.Text);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Http post
                    HttpResponseMessage response = await client.PostAsJsonAsync("api/HeartBeat/AddNewHeartBeat", heartBeat);

                    if (response.IsSuccessStatusCode)
                    {
                        textBox3.AppendText("HeartBeat Posted succesfully!\n");
                        PrintPost(heartBeat);
                    }
                    else
                    {
                        textBox3.AppendText("Attempt unsuccesfull!\n\n");
                        
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Attempt unsuccesfull!\n\n" + ex.Message);
                    Program.canContinue = false;
                }
            }

        }
        

         void PrintPost(HeartBeat heartBeat)
        {
            textBox3.AppendText(string.Format("Your heart beat rate: {0}\n{1}\n\n", heartBeat.SampleDate, heartBeat.SampleDate));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.canContinue = false;
        }
    }
}
