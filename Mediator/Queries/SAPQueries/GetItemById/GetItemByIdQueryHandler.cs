

using MediatR;
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.SAPRepository.SAPItemRepository;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetItemById
{
    public class GetItemByIdQueryHandler(ISAPItemsRepository itemsRepository) : IRequestHandler<GetItemByIdQuery, Value>
    {
        public Task<Value> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            return itemsRepository.GetItemByIdAsync(request.ItemCode);
        }
    }
}