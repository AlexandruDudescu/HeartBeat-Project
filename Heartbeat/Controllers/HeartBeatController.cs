using Heartbeat.Repositories;
using HeartBeat_Project.Hubs;
using HeartBeat_Project.Models;
using HeartBeat_Project.Repositories;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;
using System.Web.Http;

namespace HeartBeat_Project.Controllers
{
    public class HeartBeatController : ApiController
    {
        private IHeartBeatRepository HeartBeatRepository { get; set; }

        public HeartBeatController()
        {
            HeartBeatRepository = new HeartBeatSQLRepository();
        }

        [HttpPost]
        public void AddNewHeartBeat(HeartBeat newHeartBeat)
        {
            HeartBeatRepository.AddHeartBeat(newHeartBeat);
            GlobalHost.ConnectionManager.GetHubContext<HeartBeatHub>().Clients.All.publishPost(newHeartBeat);
        }

        [HttpGet]
        public List<HeartBeat> GetLastNHeartBeats(int numberOfHeartBeats)
        {
            return HeartBeatRepository.GetLastNStatuses(numberOfHeartBeats);
        }

        [HttpGet]
        public List<HeartBeat> GetAllHeartBeats()
        {
            return HeartBeatRepository.GetAllHeartBeats();
        }
    }
}
