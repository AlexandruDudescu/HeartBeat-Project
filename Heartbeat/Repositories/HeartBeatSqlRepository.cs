using HeartBeat_Project.Repositories;
using System;
using System.Collections.Generic;
using HeartBeat_Project.Models;
using System.Data.SqlClient;

namespace Heartbeat.Repositories
{
    public class HeartBeatSQLRepository : IHeartBeatRepository
    {
        private SqlConnection sqlConnection;

        public HeartBeatSQLRepository()
        {
            string connectionString = "workstation id=HeartBeat.mssql.somee.com;packet size=4096;user id=DudeThePanda_SQLLogin_1;pwd=e214ml16s2;data source=HeartBeat.mssql.somee.com;persist security info=False;initial catalog=HeartBeat";

            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
        }

        public void AddHeartBeat(HeartBeat heartBeat)
        {
            string command = "INSERT INTO Heartbeats(HearBeatRate , SampleDate ) VALUES ('" + heartBeat.HearBeatRate.ToString() + "','" + heartBeat.SampleDate.ToString() + "'); ";
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            sqlCommand.ExecuteNonQuery();
        }

        public List<HeartBeat> GetAllHeartBeats()
        {
            return null;
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