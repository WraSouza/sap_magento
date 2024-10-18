using static SAP_MAGENTO.Models.MagentoModels.OrdersResponse;

namespace SAP_MAGENTO.Repositories.MagentoRepositories.MagentoOrdersRepository
{
    public interface IMagentoOrdersRepository
    {
        Task<List<Item>> GetAllOrdersAsync();
    }
}