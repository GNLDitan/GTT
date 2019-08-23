using GlobalTravelTradeApi.Models;
using GlobalTravelTradeApi.Helper;
using Npgsql;

namespace GlobalTravelTradeApi.DataAccess.Application
{
    public interface IPopupService
    {
        Landing GetAll();
    }

    public class PopupService : BaseNpgSqlServerService, IPopupService
    {

        public PopupService(INpgSqlServerRepository npgSqlServerRepository,
            IAppSettings appSettings)  : base(npgSqlServerRepository, appSettings)
        {

        }

        public Landing GetAll() 
        {
            return new Landing();
        }
    }
}