using AirFranceDI22Model.Dao;
using AirFranceDI22Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ClientAirFranceDI22.ViewModels
{
    public class VolLightViewModel: BaseViewModel
    {
        public VolLightDto Vol { get; }

        public VolLightViewModel(VolLightDto volLight) 
        {
            Vol = volLight;
        }
        public string Horaires
        => Vol.DateHeureDepart.ToString("HH:mm") + " - " + Vol.DateHeureArrivee.ToString("HH:mm");


        private Visibility detailVisible = Visibility.Collapsed;
        public Visibility DetailVisible
        {
            get { return detailVisible; }
            set { 
                detailVisible = value; 
                OnPropertyChanged();
            }
        }







    }
}
