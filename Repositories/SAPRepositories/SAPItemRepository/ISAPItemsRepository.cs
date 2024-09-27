using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Repositories.SAPRepository.SAPItemRepository
{
    public interface ISAPItemsRepository
    {
        Task<ItemSAP> GetAllItemsSAPAsync();
        Task<ItemSAP> GetItemByIdAsync(string itemCode);
    }
}