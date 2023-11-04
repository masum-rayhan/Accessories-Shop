using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accessories.DataAccess.Utils;

public static class SD
{
    public const string SD_Storage_Container = "accessories";

    public const string Status_Pending = "Pending";
    public const string Status_InProcess = "Being Prepared";
    public const string Status_Ready = "Ready for Pickup";
    public const string Status_Completed = "Completed";
    public const string Status_Cancelled = "Cancelled";
}
