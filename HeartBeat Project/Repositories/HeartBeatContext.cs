using HeartBeat_Project.Models;
using System.Data.Entity;

namespace HeartBeat_Project.Repositories
{
    public class HeartBeatContext:DbContext
    {
        public DbSet<HeartBeat> HeartBeats { get; set; }
        public  HeartBeatContext() : base("name=HeartBeatDbConnectionString")
        {

        }
    }
}