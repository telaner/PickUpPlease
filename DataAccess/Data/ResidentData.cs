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

public class ResidentData
{
    
    
    public IEnumerable<string> GetBuilding() 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            var result = connection.Query<string>("dbo.GetBuilding").ToList();
            return result;
        }

    }

    public IEnumerable<string> GetHouseNumber() 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB")))
        {
            var result = SqlMapper.Query<string>(connection,"dbo.GetHouseNumber").ToList();
            return result;
        }
    }
        
    public int GetId(string houseNumber, string building) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            var results = connection.QuerySingleOrDefault<int>("dbo.residents_GetId @Housenumber, @Building", new { Housenumber = houseNumber, Building = building });

            return results;
        }
    }

    public void DeleteMessage(int residentId) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            connection.Execute("dbo.RemoveMessage @ResidentID", new { ResidentID = residentId });
        }
    }
        

    public IEnumerable<string> GetMessage(int Id) 
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB"))) 
        {
            var results = connection.Query<string>("dbo.ViewMessage @ResidentID", new { ResidentID = Id });
            if (results == null)
            {
                results = new List<string>();
                return results;
            }
            else
            return results;
        }
        
    }

    public void SendPickUp(PendingPickUp pending)
    {
        using (IDbConnection connection = new SqlConnection(Helper.CnnVal("PickUpPleaseDB")))
        {
            List<PendingPickUp> pendingpickup = new List<PendingPickUp>();
            pendingpickup.Add(pending);
            connection.Execute("dbo.SendPickUp @ResidentId", pendingpickup);
        }

        
    }
}
