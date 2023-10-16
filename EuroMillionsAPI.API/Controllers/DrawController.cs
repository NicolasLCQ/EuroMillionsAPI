using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EuroMillionsAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrawController : ControllerBase
    {
        public DrawService _drawService { get; set; }
        public DrawController(DrawService drawService) {
            _drawService = drawService;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Draw> Get()
        {
            return _drawService.getAll();
        }


    }
}
