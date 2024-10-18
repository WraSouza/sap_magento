using System.Net.Http.Headers;
using Newtonsoft.Json;
using SAP_MAGENTO.Models.MagentoModels;
using static SAP_MAGENTO.Models.MagentoModels.OrdersResponse;

namespace SAP_MAGENTO.Repositories.MagentoRepositories.MagentoOrdersRepository
{
    public class MagentoOrdersRepository : IMagentoOrdersRepository
    {
        readonly string url = "https://www.lojatiaraju.com.br/rest/all/V1/orders?searchCriteria[currentPage]=1";
        public async Task<List<Item>> GetAllOrdersAsync()
        {
            List<Item> orders = [];
            var content = File.ReadAllLines(@"C:\Users\wladimir.souza\Downloads\token_loja.txt");

             HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; 

             using (var client = new HttpClient(clientHandler))
             {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", content[0]);
                
                var responseLogin = client.GetAsync(url);

                string datasFromStore = await responseLogin.Result.Content.ReadAsStringAsync();

                Root? itens = JsonConvert.DeserializeObject<Root>(datasFromStore);

                 for(int i = 0; i < itens.total_count ; i++)
                 {                    
                     if(itens.items[i].status == "processing")
                     {                        
                        orders.Add(itens.items[i]);
                     }    
                 }

                return orders;
             }
        }
    }
}