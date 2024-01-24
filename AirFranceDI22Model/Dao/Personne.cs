using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirFranceDI22Model.Dao; 
public abstract class Personne 
{
    [Required]
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [StringLength(80)]
    [Column("nom")]
    public string Nom { get; set; } = string.Empty;

    [StringLength(80)]
    [Column("prenom")]
    public string Prenom { get; set; } = string.Empty;
}
