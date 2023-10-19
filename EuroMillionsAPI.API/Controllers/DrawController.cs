using EuroMillionsAPI.Entities;
using EuroMillionsAPI.Helpers;
using EuroMillionsAPI.Services;
using Microsoft.AspNetCore.Mvc;


namespace EuroMillionsAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DrawController : ControllerBase
    {
        public DrawService _drawService { get; set; }
        public Downloader _downlaoder { get; set; }
        public CsvParser _csvParser { get; set; }
        public DrawController(DrawService drawService, Downloader helper, CsvParser csvParser)
        {
            this._drawService = drawService;
            this._downlaoder = helper;
            this._csvParser = csvParser;
        }

        [HttpGet(Name = "GetAll")]
        public IEnumerable<Draw> Get()
        {
            return _drawService.getAll();
        }

        [HttpPost(Name = "Synchornize")]
        public List<Draw> Synchronize()
        {
            string tempDir = Directory.CreateTempSubdirectory().FullName;

            _downlaoder.DownloadDrawResultFromFdjHistoryToDir(tempDir);
            List<Draw> draws = _csvParser.getAllDrawsFromDirectoryContainingEuromillionCsvFiles(tempDir);

            Directory.Delete(tempDir);

            return draws;
        }


    }
}
