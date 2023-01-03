using System.ComponentModel.DataAnnotations;

namespace NRM1_mysiteproject.Models.Entities
{
    public class Iletisim
    {
        [Key]
        public int IletisimID { get; set; }
        [MaxLength(50)]
        public string Ad { get; set; }
        [MaxLength(50)]
        public string Soyad { get; set; }
        [MaxLength(255)]
        public string Eposta { get; set; }
        public string Mesaj { get; set; }
    }
}
