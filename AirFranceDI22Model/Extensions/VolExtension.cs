using AirFranceDI22Model.Dao;
using AirFranceDI22Model.Dto;

namespace AirFranceDI22Model.Extensions;
public static class VolExtension
{
    public static VolLightDto ToLightDto(this Vol vol)
    {
        return new VolLightDto
        {
            Id = vol.Id,
            DateHeureDepart = vol.DateHeureDepart,
            DateHeureArrivee = vol.DateHeureArrivee,
            Compagnie = vol.Compagnie?.Nom ?? string.Empty,
            Depart = vol.AeroportDepart?.Nom ?? string.Empty,
            Arrivee = vol.AeroportArrivee?.Nom ?? string.Empty,
        };
    }

    public static VolDto ToDto(this Vol vol)
    {
        return new VolDto
        {
            Id = vol.Id,
            NumeroVol = vol.NumeroVol,
            DateHeureDepart = vol.DateHeureDepart,
            DateHeureArrivee = vol.DateHeureArrivee,
            Compagnie = vol.Compagnie?.Nom ?? string.Empty,
            Depart = vol.AeroportDepart?.Nom ?? string.Empty,
            Arrivee = vol.AeroportArrivee?.Nom ?? string.Empty,
        };
    }
}
