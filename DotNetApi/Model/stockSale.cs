using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApi.Model
{
    public class stockSale
    {
        [Key]
        public int salesId {  get; set; }
        public string invoiceNo {  get; set; }
        public string CustomerName {  get; set; }
        public int?MobileNo { get; set; }
        public DateTime saledate { get; set; }
        public int productId {  get; set; }
        public int quantity {  get; set; }
        public int totalAmt {  get; set; }
        
    }
}
