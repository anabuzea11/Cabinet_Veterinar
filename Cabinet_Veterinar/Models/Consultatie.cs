namespace Cabinet_Veterinar.Models
{
    public class Consultatie
    {
        public int ID { get; set; }
        public DateTime Data_Consultatie { get; set; }
        public string Diagnostic {  get; set; }
        public int Pret {  get; set; } 
        public ICollection<Pacient>? Pacienti { get; set; }
    }
}
