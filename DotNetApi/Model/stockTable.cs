using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApi.Model
{
    public class stockTable
    {
        [Key]
        public int stockId { get; set; }
        public int productId {  get; set; }
        public int quantity {  get; set; }
        public DateTime createdDate { get; set; }
        public DateTime updatedDate { get; set; }
        
      
    }
}
