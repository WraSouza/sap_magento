using MediatR;
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.SAPRepositories.SAPBusinessPartnerRepository;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPByCPF
{
    public class GetBPByCPFQueryHandler(IBusinessPartnerRepository repository) : IRequestHandler<GetBPByCPFQuery, BusinessPartnerSAP>
    {
        public async Task<BusinessPartnerSAP> Handle(GetBPByCPFQuery request, CancellationToken cancellationToken)
        {
            var businessPartner = await repository.GetBusinessPartnerSAPAsync(request.TaxId4);

            return businessPartner;
        }
    }
}