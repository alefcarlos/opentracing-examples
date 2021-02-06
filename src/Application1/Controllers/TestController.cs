using Application1.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTracing;
using System.Threading.Tasks;

namespace Application1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> logger;
        private readonly ITracer tracer;
        private readonly Rule1 rule1;
        private readonly Rule2 rule2;
        private readonly Rule3 rule3;

        public TestController(ILogger<TestController> logger, ITracer tracer, Rule1 rule1, Rule2 rule2, Rule3 rule3)
        {
            this.logger = logger;
            this.tracer = tracer;
            this.rule1 = rule1;
            this.rule2 = rule2;
            this.rule3 = rule3;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync()
        {
            var result = await rule1.ValidateAsync();

            if (!result)
                return BadRequest();

            result = await rule2.ValidateAsync();

            if (!result)
                return BadRequest();

            result = await rule3.ValidateAsync();

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
