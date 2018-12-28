namespace Cqrs.Service.QueryContracts
{
    public interface IQueryDispatcher
    {
        TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult : IQueryResult;
    }
}