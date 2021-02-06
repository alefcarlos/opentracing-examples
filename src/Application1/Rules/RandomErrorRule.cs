using OpenTracing;
using System;

namespace Application1.Rules
{
    public class RandomErrorRule : RuleBase
    {
        private readonly Random rdn;

        public RandomErrorRule(ITracer tracer, Random rdn) : base(tracer)
        {
            this.rdn = rdn;
        }

        protected override bool Execute()
        {
            var value = rdn.Next(2);
            tracer.ActiveSpan.SetTag("random", value);

            return value == 1;
        }
    }
}
