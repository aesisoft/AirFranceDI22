using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AirFranceDI22Model.Enums;

namespace AirFranceDI22Model.Dao;
public class Reservation
{
    [Required]
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(80)]
    [Column("reference")]
    public string Reference { get; set; } = string.Empty;
    [Column("etat")]
    public EtatsReservation Etat { get; set; }

    [Column("dateReservation")]
    public DateTime DateReservation { get; set; }

    [ForeignKey(nameof(Vol))]
    [Column("volId")]
    public int VolId { get; set; }
    public virtual Vol? Vol { get; set; } = null!;

    [ForeignKey(nameof(Client))]
    [Column("clientId")]
    public int ClientId { get; set; }
    public virtual Client? Client { get; set; } = null!;

    [ForeignKey(nameof(Passager))]
    [Column("passagerId")]
    public int PassagerId { get; set; }
    public virtual Passager? Passager { get; set; } = null!;
}


