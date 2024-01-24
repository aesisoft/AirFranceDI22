using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirFranceDI22Model.Dao; 
public class Passager : Personne
{
    [StringLength(40)]
    [Column("pieceIdentite")]
    public string? PieceIdentite { get; set; } 

    public virtual ICollection<Reservation>? Reservations { get; set; }
}
