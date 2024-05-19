using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApi.Model
{
    public class stockPurchase
    {
        [Key]
        public int purchaseId {  get; set; }
       
        public DateTime purchaseDate { get; set; }
        
        public int productId { get; set; }
       
        public int quantity {  get; set; }
        
        public string supplierName {  get; set; }
        
        public double invoiceAmt { get; set;}
        
        public string invoiceNo { get; set; }
      


    }
}
