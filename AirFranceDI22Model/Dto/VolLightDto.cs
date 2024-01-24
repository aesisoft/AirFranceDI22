namespace AirFranceDI22Model.Dto;
public class VolLightDto
{
    public int Id { get; set; }
    public DateTime DateHeureDepart { get; set; }
    public DateTime DateHeureArrivee { get; set; }
    public string Compagnie { get; set; } = null!;
    public string Depart { get; set; } = null!;
    public string Arrivee { get; set; } = null!;

    public double Duree
        => (DateHeureArrivee - DateHeureDepart).TotalMinutes; 

}
