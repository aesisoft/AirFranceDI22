using AirFranceDI22Model.Dto;
using ClientAirFranceDI22.Services;
using ClientAirFranceDI22.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClientAirFranceDI22.ViewModels;

public class VolsViewModel : BaseViewModel
{
    public ObservableCollection<VolLightViewModel> ListeVols { get; set; } = new();
    public int NombreListeVols { get => ListeVols.Count(); }

   

    public void RechercherLesVols(DateTime selectedDate)
    {
        ListeVols.Clear();
        OnPropertyChanged(nameof(NombreListeVols));

        Task.Run(async () =>
        {
            return await HttpClientService.GetVolLights(selectedDate);

        }).ContinueWith(t =>
        {
            foreach (var volLight in t.Result)
            {
                try
                {
                    ListeVols.Add(new VolLightViewModel(volLight));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            OnPropertyChanged(nameof(NombreListeVols));

        }, TaskScheduler.FromCurrentSynchronizationContext());


    }
}