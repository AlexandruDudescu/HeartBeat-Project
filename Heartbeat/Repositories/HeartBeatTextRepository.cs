using HeartBeat_Project.Repositories;
using System;
using System.Collections.Generic;
using HeartBeat_Project.Models;
using System.IO;

namespace Heartbeat.Repositories
{
    public class HeartBeatTextRepository : IHeartBeatRepository
    {
        public HeartBeatTextRepository()
        {

        }

        public void AddHeartBeat(HeartBeat heartBeat)
        {
            using (StreamWriter writetext = new StreamWriter(@"Data.config"))
            {
                writetext.WriteLine(heartBeat.HearBeatRate+"\n"+heartBeat.SampleDate);
                writetext.Dispose();
            }
        }

        public List<HeartBeat> GetAllHeartBeats()
        {
            List<HeartBeat> heartBeatList = null;
            HeartBeat heartBeat = new HeartBeat();

            using (StreamReader readtext = new StreamReader(@"Data.config"))
            {
                string info = " ";
                while (info != null)
                {
                    try
                    {
                        info = readtext.ReadLine();
                        heartBeat.HearBeatRate = int.Parse(info);

                        info = readtext.ReadLine();
                        heartBeat.SampleDate = info;

                        info = readtext.ReadLine();

                        heartBeatList.Add(heartBeat);
                    }
                    catch
                    {
                    }
                }
                readtext.Dispose();
            }

            return heartBeatList;
        }

        public HeartBeat GetLastHeartBeat()
        {
            throw new NotImplementedException();
        }

        public List<HeartBeat> GetLastNStatuses(int numberOfStatuses)
        {
            throw new NotImplementedException();
        }
    }
}