using System.ComponentModel.DataAnnotations;

namespace NRM1_mysiteproject.Models.Entities
{
    public class Hakkimda
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Baslik { get; set; }
        public string Yazi { get; set; }
        public DateTime YaziTarih { get; set; }
        [MaxLength(255)]
        public string? YaziFoto { get; set; }
    }
}
