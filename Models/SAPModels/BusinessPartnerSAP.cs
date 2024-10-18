using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SAP_MAGENTO.Models.SAPModels
{
    public class BusinessPartnerSAP
    {
        public BusinessPartnerSAP(string cardName, string rua,string numero, string bairro, string zipCode, string cidade, string telefone, string cPF, string email)
        {
             CardName = cardName;
             Street = rua;
             StreetNo = numero;
             Block = bairro;
             ZipCode = zipCode;
             City = cidade;
             Phone1 = telefone;
             TaxId4 = cPF;
             EmailAddress = email;
             GroupCode = 109;
             Series = 74;
             CardType = "cCustomer";
         }

         [Required]
         public string CardName { get; private set; }
         [Required]
         public string Street { get; private set; }
         [Required]
         public string StreetNo { get; private set; }
         [Required]
         public string Block { get; private set; }
         [Required]
         [StringLength(9)]
         public string ZipCode { get; private set; }
         [Required]
         public string City { get; private set; }
         public string? Phone1 { get; private set; }
         [Required]
         public string TaxId4 { get; private set; }
         [Required]
         public string EmailAddress { get; private set; }
         public int GroupCode { get; private set; }
         public int Series { get; private set; }
         public string CardType { get; private set; }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
   

    public class BPAddress
    {
            public BPAddress( string street, string block, string zipCode, string city, string state, string streetNo)
            {
                AddressName = "COBRANÇA";
                Street = street;
                Block = block;
                ZipCode = zipCode;
                City = city;               
                State = state;                 
                StreetNo = streetNo;
            }

        public string AddressName { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Block { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;        
        public string State { get; set; } = string.Empty;       
        public string StreetNo { get; set; } = string.Empty;       
       
       
    }

    

    public class BPFiscalTaxIDCollection
    {
            public BPFiscalTaxIDCollection(string taxId0, string taxId1, string taxId4)
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
        public string BPCode { get; set; } = string.Empty;
       
    }  

    public class SAPBusinessPartner
    {
            public SAPBusinessPartner(string cardName, string phone1, string emailAddress, List<BPFiscalTaxIDCollection>? bPFiscalTaxIDCollection, List<BPAddress>? bPAddresses)
            {                
                CardName = cardName;
                CardType = "C";
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