using System.Net;
using System.Text;
using Newtonsoft.Json;
using SAP_MAGENTO.Helpers;
using SAP_MAGENTO.Models.SAPModels;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerResponse;
using static SAP_MAGENTO.Models.SAPModels.BusinessPartnerSAP;

namespace SAP_MAGENTO.Repositories.SAPRepositories.SAPBusinessPartnerRepository
{
    public class BusinessPartnerRepository(LoginHelper loginHelper) : IBusinessPartnerRepository
    {
        private readonly string urlBusinessPartner = "https://linux-7lxj:50000/b1s/v1/BusinessPartners";

        public async Task<bool> CreateBusinessPartnerSAPAsync(SAPBusinessPartner partnerSAP)
        {
            bool resultado = false;

             HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

            TokenSAP token = await loginHelper.RealizarLogin();

            string json = JsonConvert.SerializeObject(partnerSAP);

            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

             using (var client = new HttpClient(clientHandler))
             {
                try
                {
                    CookieContainer cookie = new CookieContainer();    

                    client.DefaultRequestHeaders.Add("Cookie",$"B1SESSION={token.SessionId};ROUTEID=.node1"); 

                    var response = await client.PostAsync(urlBusinessPartner, content);

                    if(response.StatusCode == HttpStatusCode.OK)
                    resultado = true;
                    

                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return resultado;
                 
             }
        }       

        public Task<List<BusinessPartnerSAP>> GetAllBusinessPartnerAsync()
        {
           throw new NotImplementedException();
        }

        public async Task<BusinessPartnerSAP> GetBusinessPartnerSAPAsync(string cpf)
        {
            BusinessPartnerSAP? newBusinessPartner = null ;
            string url = $"https://linux-7lxj:50000/b1s/v1/$crossjoin(BusinessPartners,BusinessPartners/BPFiscalTaxIDCollection,BusinessPartners/BPAddresses)?$expand=BusinessPartners($select=CardCode, CardName, Phone1,EmailAddress),BusinessPartners/BPFiscalTaxIDCollection($select=BPCode,TaxId1,TaxId4),BusinessPartners/BPAddresses($select=BPCode,Street,Block,ZipCode, City, State,StreetNo)&$filter=BusinessPartners/CardCode eq BusinessPartners/BPFiscalTaxIDCollection/BPCode and BusinessPartners/BPFiscalTaxIDCollection/BPCode eq BusinessPartners/BPAddresses/BPCode and BusinessPartners/BPFiscalTaxIDCollection/TaxId4 eq '{cpf}'";
           
           HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

                TokenSAP token = await loginHelper.RealizarLogin();  

                 using (var client = new HttpClient(clientHandler))
                 {
                     CookieContainer cookie = new CookieContainer();              

                    client.DefaultRequestHeaders.Add("Cookie",$"B1SESSION={token.SessionId};ROUTEID=.node1");                   

                    var responseLogin = client.GetAsync(url);

                    string datasFromStore = await responseLogin.Result.Content.ReadAsStringAsync();

                     BusinessPartnerSAP? businessPartner = JsonConvert.DeserializeObject<BusinessPartnerSAP>(datasFromStore);

                     BPResponse newBusiness = JsonConvert.DeserializeObject<BPResponse>(datasFromStore);

                     for(int i = 0; i < newBusiness.value.Count; i++)
                     {
                        
                        newBusinessPartner = new BusinessPartnerSAP(newBusiness.value[i].BusinessPartners.CardName,newBusiness.value[i].BusinessPartnersBPAddresses.Street,
                                                                     newBusiness.value[i].BusinessPartnersBPAddresses.StreetNo, newBusiness.value[i].BusinessPartnersBPAddresses.Block
                                                                     ,newBusiness.value[i].BusinessPartnersBPAddresses.ZipCode
                                                                     ,newBusiness.value[i].BusinessPartnersBPAddresses.City,newBusiness.value[i].BusinessPartners.Phone1,newBusiness.value[i].BusinessPartnersBPFiscalTaxIDCollection.TaxId4
                                                                     ,newBusiness.value[i].BusinessPartners.EmailAddress);
                     }

                   
                     return newBusinessPartner; 
                 }         
            

                               
        }
    }
}