using System.ComponentModel.DataAnnotations;

namespace NRM1_mysiteproject.Models.Entities
{
    public class Projeler
    {
        [Key]
        public int ProjeID { get; set; }
        [MaxLength(150)]
        public string ProjeAdi { get; set; }
        public string ProjeAciklamasi { get; set; }
        public DateTime ProjeTarihi { get; set; }
        [MaxLength(155)]
        public string ProjeFoto { get; set; }
    }
}
