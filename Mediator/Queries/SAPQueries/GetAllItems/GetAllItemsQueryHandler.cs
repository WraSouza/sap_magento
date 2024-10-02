using MediatR;
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.SAPRepository.SAPItemRepository;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetAllItems
{
    public class GetAllItemsQueryHandler(ISAPItemsRepository itemsRepository) : IRequestHandler<GetAllItemsQuery, ItemSAP>
    {
        public async Task<ItemSAP> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return await itemsRepository.GetAllItemsSAPAsync();
        }
    }
}