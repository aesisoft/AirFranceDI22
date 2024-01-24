using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirFranceDI22Model.Dao; 
public class Client : Personne
{
    [StringLength(16)]
    [Column("codeClient")]
    public string CodeClient { get; set; } = string.Empty;
}
