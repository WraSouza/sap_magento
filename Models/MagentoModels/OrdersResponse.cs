

namespace SAP_MAGENTO.Models.MagentoModels
{
    public class OrdersResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string address_type { get; set; } = string.Empty;
        public string city { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string firstname { get; set; } = string.Empty;
        public string lastname { get; set; } = string.Empty;
        public string postcode { get; set; } = string.Empty;
        public string region { get; set; } = string.Empty;
        public List<string>? street { get; set; } 
        public string telephone { get; set; } = string.Empty;
        public string vat_id { get; set; } = string.Empty;
    }


    public class Item
    {            
        public string customer_email { get; set; } = string.Empty;
        public string customer_firstname { get; set; } = string.Empty;        
        public string customer_lastname { get; set; } = string.Empty;           
        public string state { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;       
        public List<Item>? items { get; set; }       
        public double? discount_invoiced { get; set; }
        public double? total_paid { get; set; }
        public double base_price { get; set; }       
        public string name { get; set; } = string.Empty;       
        public double original_price { get; set; }
        public double price { get; set; }
        public double row_invoiced { get; set; }
        public string sku { get; set; }  = string.Empty;
        public double? subtotal_invoiced { get; set; }
  
    }

    public class ParentItem
    {            
        public double base_original_price { get; set; }
        public double base_price { get; set; }      
        public int quote_item_id { get; set; }
        public int row_invoiced { get; set; }           
    }


    public class Root
    {
        public List<Item>? items { get; set; }
        public SearchCriteria? search_criteria { get; set; }
        public int total_count { get; set; }
    }

    public class SearchCriteria
    {
        public List<object>? filter_groups { get; set; }
        public int current_page { get; set; }
    }

    }
}