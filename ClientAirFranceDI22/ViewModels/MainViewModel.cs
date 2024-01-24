using ClientAirFranceDI22.Views.Clients;
using ClientAirFranceDI22.Views.Vols;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ClientAirFranceDI22.ViewModels;

public class MainViewModel : BaseViewModel
{
    #region Singleton

    private static MainViewModel instance = new MainViewModel();
    public static MainViewModel Instance => instance;

    private MainViewModel() { }

    #endregion

    public ObservableCollection<TabItem> ListTabs { get; set; } = new();
    public int TabIndex { get; set; }

    private void AfficherTab(UserControl uc, string titre)
    {
        var tab = new TabItem();
        tab.Content = uc;
        tab.Header = titre;

        ListTabs.Add(tab);
        OnPropertyChanged(nameof(ListTabs));
        TabIndex = ListTabs.Count - 1;
        OnPropertyChanged(nameof(TabIndex));
    }

    public void AfficherVols()
    {
        var uc = new ucGridVols();
        uc.DataContext = new VolsViewModel();
        AfficherTab(uc, "Vols");
    }

    public void AfficherClients()
    {
        var uc = new ucGridClients();
        uc.DataContext = new ClientsViewModel();
        AfficherTab(uc, "Clients");
    }

    public void AfficherUnVol(VolLightViewModel vm)
    {
        var uc = new ucDetailVol();
        uc.DataContext = vm;
        AfficherTab(uc, $"Vol {vm.Vol.Id}");
    }

    public void FermerTabActif()
    {
        if(ListTabs.Count > 0 && TabIndex < ListTabs.Count)
        {
            ListTabs.RemoveAt(TabIndex);
            OnPropertyChanged(nameof(ListTabs));
        }
        
    }
}
