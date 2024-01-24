using ClientAirFranceDI22.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace ClientAirFranceDI22.Views
{
    public partial class ucSearchVols : UserControl
    {
        public ucSearchVols()
        {
            InitializeComponent();
            dtpDate.SelectedDate = DateTime.Now;
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            msgError.Visibility = Visibility.Collapsed;
            if (dtpDate.SelectedDate >= DateTime.Now.AddDays(-1))
            {
                var vm = (VolsViewModel)this.DataContext;
                vm.RechercherLesVols(dtpDate.SelectedDate.Value) ;
            }
            else
            {
                msgError.Visibility = Visibility.Visible;
            }
        }
    }
}
