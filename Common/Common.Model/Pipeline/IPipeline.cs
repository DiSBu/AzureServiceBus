namespace Common.Model.Pipeline
{
    public interface IPipeline<TIn, TOut>
    {
        TOut Process(TIn input);
        IPipeline<TIn, TOut> Register(IStep<TIn, TOut> step);
    }
}