using OpenTracing;
using System;

namespace Application1.Rules
{
    public class Rule1 : RandomErrorRule
    {
        public Rule1(ITracer tracer, Random rdn) : base(tracer, rdn)
        {
        }
    }
}
