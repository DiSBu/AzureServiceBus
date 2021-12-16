namespace Common.Model.Pipeline
{
    public interface IStep<TIn, TOut>
    {
        TOut Execute(TIn input);
    }
}