using OpenTracing;
using System.Threading.Tasks;

namespace Application1.Rules
{
    public class Rule1 : RuleBase
    {
        private readonly IApplication2ApiClient client;

        public Rule1(ITracer tracer, IApplication2ApiClient client) : base(tracer)
        {
            this.client = client;
        }

        protected override async Task<bool> ExecuteAsync()
        {
            var result = await client.GetWeatherForecastsAsync();

            result.EnsureSuccessStatusCode();

            return true;
        }
    }
}
