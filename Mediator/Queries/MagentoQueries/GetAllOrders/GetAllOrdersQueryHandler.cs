using MediatR;
using SAP_MAGENTO.Repositories.MagentoRepositories.MagentoOrdersRepository;
using static SAP_MAGENTO.Models.MagentoModels.OrdersResponse;

namespace SAP_MAGENTO.Mediator.Queries.MagentoQueries.GetAllOrders
{
    public class GetAllOrdersQueryHandler(IMagentoOrdersRepository repository) : IRequestHandler<GetAllOrdersQuery, List<Item>>
    {
        public Task<List<Item>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            return repository.GetAllOrdersAsync();
        }
    }
}