using System.ComponentModel.DataAnnotations;

namespace NRM1_mysiteproject.Models.Entities
{
    public class AdminUser
    {
        [Key]
        public int UserID { get; set; }
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
