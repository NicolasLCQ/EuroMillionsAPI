using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Services;
using EuroMillionsAPI.Synchronizer;
using Microsoft.AspNetCore.Mvc;

namespace EuroMillionsAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrawController : ControllerBase
    {
        public DrawService _drawService { get; set; }
        public Helpers _downloader { get; set; }
        public DrawController(DrawService drawService, Helpers downloader)
        {
            _drawService = drawService;
            _downloader = downloader;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Draw> Get()
        {
            return _drawService.getAll();
        }

        [HttpPost(Name = "Synchornize")]
        public void Synchronize()
        {
            _downloader.DownloadDrawResultFromFdjHistory();
        }


    }
}
