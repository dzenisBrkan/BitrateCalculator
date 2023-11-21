using BitrateCalculator.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BitrateCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirateCalculatorController : ControllerBase
    {
        private readonly IBitrate _bitrate;

        public BirateCalculatorController(IBitrate bitrate)
        {
            _bitrate = bitrate;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _bitrate.GetAll();

            return Ok(data);
        }

        [HttpPost]
        public IActionResult Post([FromBody] string json)
        {
            var data = _bitrate.UploadVideo(json);

            return Ok(data);
        }
    }
}
