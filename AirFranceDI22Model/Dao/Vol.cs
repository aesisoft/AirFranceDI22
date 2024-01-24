using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AirFranceDI22Model.Dto;

namespace AirFranceDI22Model.Dao;
public class Vol
{
    [Required]
    [Key]
    [Column("id")]
    public int Id { get; set; }
    [StringLength(20)]
    [Column("numeroVol")]
    public string NumeroVol { get; set; } = string.Empty;
    [Column("ouvertResa")]
    public bool OuvertResa { get; set; }
    [Column("dateHeureDepart")]
    public DateTime DateHeureDepart { get; set;}
    [Column("dateHeureArrivee")]
    public DateTime DateHeureArrivee { get; set;}

    [ForeignKey(nameof(Compagnie))]
    [Column("compagnieId")]
    public int CompagnieId { get; set; }
    public virtual Compagnie? Compagnie { get; set; } 

    [ForeignKey(nameof(AeroportDepart))]
    [Column("aeroportDepartId")]
    public int AeroportDepartId { get; set; }
    public virtual Aeroport? AeroportDepart { get; set; }

    [ForeignKey(nameof(AeroportArrivee))]
    [Column("aeroportArriveeId")]
    public int AeroportArriveeId { get; set; }
    public virtual Aeroport? AeroportArrivee { get; set; } 

    public virtual ICollection<Vol>? Escales { get; set; }

   
}
