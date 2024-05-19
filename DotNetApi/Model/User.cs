using System.ComponentModel.DataAnnotations;

namespace AngularApi.Model
{
    public class User
    {
        [Key]
        public int userId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }    


    }
}
