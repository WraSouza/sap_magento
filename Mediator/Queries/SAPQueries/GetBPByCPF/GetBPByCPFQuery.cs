using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using SAP_MAGENTO.Models.SAPModels;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPByCPF
{
    public class GetBPByCPFQuery : IRequest<BusinessPartnerSAP>
    {
         public GetBPByCPFQuery(string taxId4)
            {                             
                TaxId4 = taxId4;                
            }
       
        public string TaxId4 { get; set; } = string.Empty;       
       
    }
}