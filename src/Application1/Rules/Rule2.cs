using OpenTracing;
using System;

namespace Application1.Rules
{
    public class Rule2 : RandomErrorRule
    {
        public Rule2(ITracer tracer, Random rdn) : base(tracer, rdn)
        {
        }
    }
}
