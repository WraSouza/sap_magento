
using MediatR;
using SAP_MAGENTO.Models.SAPModels;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetItemById
{
    public class GetItemByIdQuery : IRequest<Value>
    {
         public GetItemByIdQuery(string itemCode)
        {
            ItemCode = itemCode;
        }
        
        public string ItemCode { get; set; } = string.Empty;
        public string CardName { get; set; } = string.Empty;
        public string BarCode { get; set; } = string.Empty;
        public string OnHand { get; set; } = string.Empty;
    }
}