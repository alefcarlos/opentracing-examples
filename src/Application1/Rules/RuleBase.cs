using OpenTracing;
using OpenTracing.Tag;

namespace Application1.Rules
{
    public abstract class RuleBase
    {
        protected readonly ITracer tracer;

        protected RuleBase(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public bool Validate()
        {
            using var scope = tracer.BuildSpan($"Validation {GetType().Name}").StartActive();

            var result = Execute();

            if (!result)
                Tags.Error.Set(scope.Span, true);

            return result;
        }

        protected abstract bool Execute();
    }
}
