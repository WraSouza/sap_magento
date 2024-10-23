using MediatR;
using SAP_MAGENTO.Mediator.Queries.SAPQueries.GetBPById;
using SAP_MAGENTO.Repositories.SAPRepositories.SAPBusinessPartnerRepository;
using static SAP_MAGENTO.Mediator.Commands.SAPCommands.InsertBpCommand.InsertBusinessPartnerCommand;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Mediator.Commands.SAPCommands.InsertBpCommand
{
    public class InsertBusinessPartnerCommandHandler(IBusinessPartnerRepository sapRepository) : IRequestHandler<SAPBusinessPartnerCommand, SAPBusinessPartner>
    {       
        public async Task<SAPBusinessPartner> Handle(SAPBusinessPartnerCommand request, CancellationToken cancellationToken)
        {

            //throw new NotImplementedException();
            var businessPartner = new SAPBusinessPartner(request.CardName,request.Phone1,request.EmailAddress, request.BPFiscalTaxIDCollection, request.BPAddresses);
            //var businessPartner = new SAPBusinessPartner(request.CardName, request.Rua,request.Numero,request.Bairro,request.CEP, request.Cidade,request.Telefone,request.CPF, request.Email);
            
            return await sapRepository.CreateBusinessPartnerSAPAsync(businessPartner);

            //return Unit.Value;
        }
    }
}