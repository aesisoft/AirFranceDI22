using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirFranceDI22Model.Dto;
public class VolDto
{
    public int Id { get; set; }

    public string NumeroVol { get; set; } = null!;
    public DateTime DateHeureDepart { get; set; }
    public DateTime DateHeureArrivee { get; set; }
    public string Compagnie { get; set; } = null!;
    public string Depart { get; set; } = null!;
    public string Arrivee { get; set; } = null!;

    public double Duree
        => (DateHeureArrivee - DateHeureDepart).TotalMinutes; 

}
