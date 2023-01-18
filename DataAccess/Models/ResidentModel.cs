using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class ResidentModel
{
    public int Id { get; set; }
    public string  Builidng { get; set; }
    public string HouseNumber { get; set; }
    public string TrashValet { get; set; }
}
