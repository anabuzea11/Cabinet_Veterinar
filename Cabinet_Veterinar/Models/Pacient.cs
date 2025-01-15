namespace Cabinet_Veterinar.Models
{
    public class Pacient
    {
        public int ID { get; set; }
        public string Nume { get; set; }
        public string Specie { get; set; }
        public int Varsta { get; set; }
        public int? ProprietarID { get; set; }
        public Proprietar? Proprietar { get; set; }
        public int? ConsultatieID { get; set; }
        public Consultatie? Consultatie { get; set; }
    }
}
