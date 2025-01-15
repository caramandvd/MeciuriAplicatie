namespace MeciuriAplicatie.Models
{
    public class SportTeam
    {
        public int Id { get; set; } // Identificator unic
        public string TeamName { get; set; } // Numele echipei
        public string Coach { get; set; } // Numele antrenorului
        public string City { get; set; } // Orașul echipei
    }
}
