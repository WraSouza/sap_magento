

using MediatR;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Mediator.Commands.SAPCommands.InsertBpCommand
{
    public class InsertBusinessPartnerCommand 
    {
       
    public class BPFiscalTaxIDCollectionCommand
    {
            public BPFiscalTaxIDCollectionCommand(string taxId0, string taxId1, string taxId4)
            {
                TaxId0 = taxId0;
                TaxId1 = taxId1;               
                TaxId4 = taxId4;                
            }

        public string TaxId0 { get; set; } = string.Empty;
        public string TaxId1 { get; set; } = string.Empty;
        public string TaxId2 { get; set; } = string.Empty;
        public string TaxId3 { get; set; } = string.Empty;
        public string TaxId4 { get; set; } = string.Empty;      
        
       
    }  

    public class SAPBusinessPartnerCommand : IRequest<SAPBusinessPartner>
    {
            public SAPBusinessPartnerCommand( string cardName, string phone1, string emailAddress, List<BPFiscalTaxIDCollection>? bPFiscalTaxIDCollection, List<BPAddress>? bPAddresses)
            {                
                CardName = cardName;
                CardType = "cCustomer";
                GroupCode = 109;
                Phone1 = phone1;
                EmailAddress = emailAddress;
                Series = 74;
                BPFiscalTaxIDCollection = bPFiscalTaxIDCollection;
                BPAddresses = bPAddresses;
            }

          
        public string CardName { get; set; } = string.Empty;
        public string CardType { get; set; } = string.Empty;
        public int GroupCode { get; set; }
        public string Phone1 { get; set; } = string.Empty;    
        public string EmailAddress { get; set; } = string.Empty;         
        public int Series { get; set; }
        public List<BPFiscalTaxIDCollection>? BPFiscalTaxIDCollection { get; set; }      
        public List<BPAddress>? BPAddresses { get; set; }
       
    }
    }
}