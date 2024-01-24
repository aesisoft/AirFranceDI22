using ClientAirFranceDI22.ViewModels;
using ClientAirFranceDI22.Views.Clients;
using ClientAirFranceDI22.Views.Vols;
using System.Windows;

namespace ClientAirFranceDI22;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void MenuVols_Click(object sender, RoutedEventArgs e)
    {
        mainCC.Content = null;
        var uc = new ucGridVols();
        uc.DataContext = new VolsViewModel();
        mainCC.Content = uc;
    }

    private void MenuClients_Click(object sender, RoutedEventArgs e)
    {
        mainCC.Content = null;
        var uc = new ucGridClients();
        uc.DataContext = new ClientsViewModel();
        mainCC.Content = uc;
    }
}