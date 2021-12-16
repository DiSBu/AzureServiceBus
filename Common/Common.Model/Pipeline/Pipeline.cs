using System.Collections.Generic;

namespace Common.Model.Pipeline
{
    public abstract class Pipeline<TIn, TOut> : IPipeline<TIn, TOut>
    {
        protected readonly List<IStep<TIn, TOut>> steps = new List<IStep<TIn, TOut>>();

        public IPipeline<TIn, TOut> Register(IStep<TIn, TOut> step)
        {
            steps.Add(step);
            return this;
        }

        public abstract TOut Process(TIn input);
    }
}
