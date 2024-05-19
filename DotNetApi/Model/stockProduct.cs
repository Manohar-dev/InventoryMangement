using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularApi.Model
{
    public class stockProduct

    {
        [Key]
        public int productId {  get; set; }
        
        public string productName { get; set; }
       
        public DateTime? createdDate { get; set; }
        
        public double Price {  get; set; }
        public string productDetail{ get; set; }

        public int userId { get; set; }
        
    }
}
