using System.ComponentModel.DataAnnotations;

namespace Cabinet_Veterinar.Models
{
    public class Proprietar
    {
        public int ID { get; set; }
        [Display(Name = "Proprietar")]
        public string Nume { get; set; }
        public string Email { get; set; }
        public ICollection<Pacient>? Pacienti { get; set; }
    }
}
