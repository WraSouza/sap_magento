
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.SAPRepository.SAPItemRepository;

namespace SAP_MAGENTO.Repositories.SAPRepositories.SAPItemsRepository
{
    public class SAPItemsRepository : ISAPItemsRepository
    {
        public Task<ItemSAP> GetAllItemsSAPAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemSAP> GetItemByIdAsync(string itemCode)
        {
            throw new NotImplementedException();
        }
    }
}