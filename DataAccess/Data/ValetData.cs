using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DataAccess.Models;
using Resident;

namespace DataAccess.Data;

public class ValetData
{
    public int GetId(int residentId) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            var results = connection.QuerySingleOrDefault<int>("dbo.GetPickUpId @ResidentId", new { ResidentId=residentId });

            return results;
        }
    }
   
    public IEnumerable<string> GetMessage() 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            var result = connection.Query<string>("dbo.GetMessages").ToList();
            return result;
        }
    }
    public void SendMessage(Incomplete incomplete) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            List<Incomplete> incompletelist = new List<Incomplete>();
            incompletelist.Add(incomplete);
            connection.Execute("dbo.SendMessage @messageID, @pickupID", incompletelist);
        }
    }

    public void CompletePickUp(Completed completed) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB")))
        {
            List<Completed> completedlist = new List<Completed>();
            completedlist.Add(completed);
            connection.Execute("dbo.CompletePickUp @pickupId", completedlist);
        }
    }

    public IEnumerable<int> GetOrders() 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            var result = connection.Query<int>("dbo.GetPendingOrders").ToList();
            return result;
        }
    }

    public int GetMessageId(string message)
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB")))
        {
            var result = connection.QuerySingleOrDefault <int>("dbo.GetMessageId @message", new {Message = message});
            return result;
        }
    }

    public void DeletePendingOrder(int pickupid)
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB")))
        {
            connection.Execute("dbo.deletePendingOrder @PickUpId", new { PickUpId = pickupid });
        }
    }

    public void SendMessageResident(int MesId, int ResId, string Mes) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB")))
        {
            List<ResidentMessageModel> residentMessages = new List<ResidentMessageModel>();
            residentMessages.Add(new ResidentMessageModel { MessageID = MesId,ResidentID = ResId, Message =Mes});
            
            connection.Execute("dbo.SendMessageResident @MessageID,@ResidentID,@Message", residentMessages );
        }

    }




}
