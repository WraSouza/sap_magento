
using System.Net;
using Newtonsoft.Json;
using SAP_MAGENTO.Helpers;
using SAP_MAGENTO.Models.SAPModels;
using SAP_MAGENTO.Repositories.SAPRepository.SAPItemRepository;

namespace SAP_MAGENTO.Repositories.SAPRepositories.SAPItemsRepository
{
    public class SAPItemsRepository(LoginHelper loginHelper) : ISAPItemsRepository
    {
        readonly string url = "https://linux-7lxj:50000/b1s/v1/Items?$select=ItemCode,ItemName,BarCode,QuantityOnStock";
       
        public async Task<ItemSAP> GetAllItemsSAPAsync()
        {

             HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

                TokenSAP token = await loginHelper.RealizarLogin();
              
                using (var client = new HttpClient(clientHandler))
                {   
                
                    CookieContainer cookie = new CookieContainer();              

                    client.DefaultRequestHeaders.Add("Cookie",$"B1SESSION={token.SessionId};ROUTEID=.node1");                   

                    var responseLogin = client.GetAsync(url);

                    string datasFromStore = await responseLogin.Result.Content.ReadAsStringAsync();

                    ItemSAP? itens = JsonConvert.DeserializeObject<ItemSAP>(datasFromStore);

                    return itens;
                    
                }
        }

        public Task<ItemSAP> GetItemByIdAsync(string itemCode)
        {
            throw new NotImplementedException();
        }
    }
}