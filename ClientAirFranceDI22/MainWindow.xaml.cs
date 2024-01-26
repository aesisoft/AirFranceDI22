using ClientAirFranceDI22.Services;
using ClientAirFranceDI22.ViewModels;
using ClientAirFranceDI22.Views.Clients;
using ClientAirFranceDI22.Views.Vols;
using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;

namespace ClientAirFranceDI22;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        this.DataContext = MainViewModel.Instance;

        Task.Run(async() =>  await HttpClientService.Login("nadine", "123@Abc"));
    }

    private void MenuVols_Click(object sender, RoutedEventArgs e)
    {
        //var uc = new ucGridVols();
        //uc.DataContext = new VolsViewModel();

        //var tab = new TabItem();
        //tab.Content = uc;
        //tab.Header = "Vols";

        //tabs.Items.Add(tab);
        MainViewModel.Instance.AfficherVols();

    }

    private void MenuClients_Click(object sender, RoutedEventArgs e)
    {
        MainViewModel.Instance.AfficherClients();
        
    }

    private void Close_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        MainViewModel.Instance.FermerTabActif();
    }

}