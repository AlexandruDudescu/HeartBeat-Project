using HeartBeat_Project.Models;
using System.Collections.Generic;

namespace HeartBeat_Project.Repositories
{
    interface IHeartBeatRepository
    {
        void AddHeartBeat(HeartBeat heartBeat);
        HeartBeat GetLastHeartBeat();
        List<HeartBeat> GetAllHeartBeats();
        List<HeartBeat> GetLastNStatuses(int numberOfStatuses);
    }
}
