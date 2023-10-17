using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace EuroMillionsAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrawController : ControllerBase
    {
        public DrawService _drawService { get; set; }
        public Helpers _helper { get; set; }
        public DrawController(DrawService drawService, Helpers helper)
        {
            _drawService = drawService;
            _helper = helper;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Draw> Get()
        {
            return _drawService.getAll();
        }

        [HttpPost(Name = "Synchornize")]
        public void Synchronize()
        {
            string tempDir = _helper.DownloadDrawResultFromFdjHistoryToTempDir();
        }


    }
}
