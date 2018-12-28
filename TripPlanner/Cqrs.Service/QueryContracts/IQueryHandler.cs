namespace Cqrs.Service.QueryContracts
{
    public interface IQueryHandler<in TQuery, out TResult>
        where TQuery : IQuery
        where TResult : IQueryResult
    {
       TResult Execute(TQuery query);
    }
}