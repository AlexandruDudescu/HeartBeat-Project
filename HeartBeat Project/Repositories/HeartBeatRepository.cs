using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HeartBeat_Project.Models;

namespace HeartBeat_Project.Repositories
{
    public class HeartBeatRepository : IHeartBeatRepository
    {
        private HeartBeatContext HeartBeatContext { get; set; }

        public HeartBeatRepository()
        {
            HeartBeatContext = new HeartBeatContext();
        }

        public void AddHeartBeat(HeartBeat heartBeat)
        {
            HeartBeatContext.HeartBeats.Add(heartBeat);
            HeartBeatContext.SaveChanges();
        }

        public List<HeartBeat> GetAllHeartBeats()
        {
            return HeartBeatContext.HeartBeats.ToList();
        }

        public HeartBeat GetLastHeartBeat()
        {
            return HeartBeatContext.HeartBeats.Last();
        }

        public List<HeartBeat> GetLastNStatuses(int numberOfStatuses)
        {
            List<HeartBeat> HeartBeatsList = HeartBeatContext.HeartBeats.OrderByDescending(hb => hb.SampleID).Take(numberOfStatuses).ToList();
            HeartBeatsList.Reverse();

            return HeartBeatsList;
        }
    }
}