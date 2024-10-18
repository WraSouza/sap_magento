using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SAP_MAGENTO.Models.SAPModels;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Repositories.SAPRepositories.SAPBusinessPartnerRepository
{
    public interface IBusinessPartnerRepository
    {
        Task<List<BusinessPartnerSAP>> GetAllBusinessPartnerAsync();
        Task<BusinessPartnerSAP> GetBusinessPartnerSAPAsync(string cpf);
        Task<bool> CreateBusinessPartnerSAPAsync(SAPBusinessPartner partnerSAP);
        
    }
}