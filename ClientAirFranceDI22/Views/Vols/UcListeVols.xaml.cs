using ClientAirFranceDI22.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientAirFranceDI22.Views
{
    /// <summary>
    /// Logique d'interaction pour UcListeVols.xaml
    /// </summary>
    public partial class UcListeVols : UserControl
    {
        public UcListeVols()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var vm = (VolLightViewModel)button.DataContext;
            MainViewModel.Instance.AfficherUnVol(vm);
        }
    }
}
