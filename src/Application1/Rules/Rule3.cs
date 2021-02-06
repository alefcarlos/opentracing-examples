using OpenTracing;
using System;

namespace Application1.Rules
{
    public class Rule3 : RandomErrorRule
    {
        public Rule3(ITracer tracer, Random rdn) : base(tracer, rdn)
        {
        }
    }
}
