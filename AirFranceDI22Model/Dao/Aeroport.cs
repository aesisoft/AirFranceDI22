using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirFranceDI22Model.Dao;
public class Aeroport
{
    [Required]
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(80)]
    [Column("nom")]
    public string Nom { get; set; } = string.Empty;

    [ForeignKey(nameof(Ville))]
    [Column("villeId")]
    public int VilleId { get; set; }
    public virtual Ville Ville { get; set; } = null!;
}
