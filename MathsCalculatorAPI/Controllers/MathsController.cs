using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MathsCalculatorAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MathsController : ControllerBase
    {
        private readonly ILogger<MathsController> _logger;

        public MathsController(ILogger<MathsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("random")]
        public decimal GetRandomNumber()
        {
            return new Random().Next(100);
        }

        [HttpPost("area/{width:int}/{height:int}")]
        public decimal GetArea(decimal width, decimal height)
        {
            return width * height;
        }
    }
}