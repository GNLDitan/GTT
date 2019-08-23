using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GlobalTravelTradeApi.DataAccess.Application;
using System;
using System.Threading.Tasks;

namespace GlobalTravelTradeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopupController : ControllerBase
    {
        public IPopupService _ipopupService;

        public PopupController(IPopupService ipopupService)
        {
            _ipopupService = ipopupService;
        }
    
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var result = _ipopupService.GetAll();

                return Ok(new {
                    id = result
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
    
}