using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

internal class ResidentMessageModel
{
    public int Id { get; set; }
    public int MessageID { get; set; }
    public int ResidentID { get; set; }
    public string Message { get; internal set; }
}
