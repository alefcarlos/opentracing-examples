using OpenTracing;
using System;
using System.Threading.Tasks;

namespace Application1.Rules
{
    public class RandomErrorRule : RuleBase
    {
        private readonly Random rdn;

        public RandomErrorRule(ITracer tracer, Random rdn) : base(tracer)
        {
            this.rdn = rdn;
        }

        protected override Task<bool> ExecuteAsync()
        {
            var value = rdn.Next(2);
            tracer.ActiveSpan.SetTag("random", value);

            return Task.FromResult(value == 1);
        }
    }
}
