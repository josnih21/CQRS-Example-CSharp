using CQRS.Query;

namespace CQRS.QueryHandler;

public interface IQueryHandler<out TResult, in TParameter> where TParameter : IQuery
{
    TResult Handle(TParameter query);
}