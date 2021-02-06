using Application1.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenTracing;

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
        public IActionResult Post()
        {
            using var scope = tracer.BuildSpan(GetType().Name).StartActive();

            var result = rule1.Validate();

            if (!result)
                return BadRequest();

            result = rule2.Validate();

            if (!result)
                return BadRequest();

            result = rule3.Validate();

            if (!result)
                return BadRequest();

            return Ok();
        }
    }
}
