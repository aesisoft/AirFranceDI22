using AirFranceDI22Model.Dao;
using ClientAirFranceDI22.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAirFranceDI22.ViewModels
{
    public class ClientsViewModel : BaseViewModel
    {
        public void AjouterClient(Client newClient)
        {
            Task.Run(async () =>await HttpClientService.PostClient(newClient));
        }


    }
}
