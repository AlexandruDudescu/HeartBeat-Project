using System.ComponentModel.DataAnnotations;

namespace HeartBeat_Project.Models
{
    public class HeartBeat
    {
        [Key]
        public int SampleID { get; set; }
        public int HearBeatRate { get; set; }
        public string SampleDate { get; set; }

        public HeartBeat(int heartBeatRate, string sampleDate)
        {
            SampleDate = sampleDate;
            HearBeatRate = heartBeatRate;
        }

        public HeartBeat()
        {
        }
    }
}