

namespace GlobalTravelTradeApi.Models
{
     public class ILanding
    {
         long Id { get; set; }
         string Url { get; set; }
         string ImageUrl { get; set; }
         int Order { get; set; }
    }

    public class Landing : ILanding
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public int Order { get; set; }
    }
}

  