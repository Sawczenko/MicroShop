using MediatR;

namespace MicroShop.Core.Interfaces.Requests.Queries
{
    public interface IQuery<TDataType> : IRequest<TDataType> { }
}
