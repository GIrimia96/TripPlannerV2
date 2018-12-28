using System;
using Autofac;
using Cqrs.Service.QueryContracts;

namespace Cqrs.Service.QueryHandlers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _componentContext;

        public QueryDispatcher(IComponentContext componentContext)
        {
            _componentContext = componentContext;
        }

        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
            where TResult : IQueryResult
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            var handler = _componentContext.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            return handler.Execute(query);
        }
    }
}