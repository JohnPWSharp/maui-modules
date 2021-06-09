using System;
using Microsoft.AspNetCore.Mvc;
using PartsService.Models;

namespace PartsService.Controllers
{
    [ApiController]
    [Route("api/parts/[controller]")]
    public class LoginController : ControllerBase
    {
        
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var authorizationToken = Guid.NewGuid().ToString();

                PartsFactory.Initialize(authorizationToken);
                
                return new JsonResult(authorizationToken);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
