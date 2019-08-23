using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalTravelTradeApi.Helper
{
    public interface IConnectionStrings
    {
        string DefaultConnection { get; set; }
        string GlobalTravelTradeConnection { get; set; }
    }

    public class ConnectionStrings : IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string GlobalTravelTradeConnection { get; set; }
    }
}