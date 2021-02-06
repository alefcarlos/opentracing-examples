using OpenTracing;
using OpenTracing.Tag;
using System.Threading.Tasks;

namespace Application1.Rules
{
    public abstract class RuleBase
    {
        protected readonly ITracer tracer;

        protected RuleBase(ITracer tracer)
        {
            this.tracer = tracer;
        }

        public async Task<bool> ValidateAsync()
        {
            using var scope = tracer.BuildSpan($"Validation {GetType().Name}").StartActive();

            var result = await ExecuteAsync();

            if (!result)
                Tags.Error.Set(scope.Span, true);

            return result;
        }

        protected abstract Task<bool> ExecuteAsync();
    }
}
