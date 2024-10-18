using MediatR;
using SAP_MAGENTO.Helpers;
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.MagentoRepositories.MagentoOrdersRepository;
using SAP_MAGENTO.Repositories.SAPRepositories.SAPBusinessPartnerRepository;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPById
{
    public class GetBPByIdQueryHandler(IBusinessPartnerRepository repository, IMagentoOrdersRepository magentoOrdersRepository) : IRequestHandler<GetBPByIdQuery, BusinessPartnerSAP>
    {
        List<BPFiscalTaxIDCollection> bpFiscal = new();
        List<BPAddress> bPAddresses= new();
        public async Task<BusinessPartnerSAP> Handle(GetBPByIdQuery request, CancellationToken cancellationToken)
        {
            var bpInMagento = await magentoOrdersRepository.GetAllOrdersAsync();

            for(int i = 0; i < bpInMagento.Count ; i++)
            {
                var businessPartner = await repository.GetBusinessPartnerSAPAsync(bpInMagento[i].billing_address.vat_id);

                if(businessPartner == null)
                {
                    for(int j = i; j < bpInMagento.Count ; j++)
                    {
                        string name = bpInMagento[j].customer_firstname + " " +bpInMagento[j].customer_lastname;

                        string fullName = RetiraAcento.RetirarAcentuacao(name);

                        BPFiscalTaxIDCollection bPFiscalTaxIDCollection = new BPFiscalTaxIDCollection("","",bpInMagento[j].billing_address.vat_id);

                        BPAddress bPAddress = new BPAddress(bpInMagento[j].billing_address.street[0],bpInMagento[j].billing_address.street[3],bpInMagento[j].billing_address.postcode.Replace("-","")
                                                            ,bpInMagento[j].billing_address.city,bpInMagento[j].billing_address.region_code,bpInMagento[j].billing_address.street[1]);

                        bPAddresses.Add(bPAddress);

                        bpFiscal.Add(bPFiscalTaxIDCollection);

                        var businessPartnerInSAP = new SAPBusinessPartner(fullName.ToUpper(),bpInMagento[j].billing_address.telephone,bpInMagento[j].billing_address.email,bpFiscal,bPAddresses);
                       
                        await repository.CreateBusinessPartnerSAPAsync(businessPartnerInSAP);
                    }                    
                    
                }
                
            }

          
            return await repository.GetBusinessPartnerSAPAsync(request.CPF);
        }
    }
}