using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestApp.Commands;
using WpfTestApp.Views;

namespace WpfTestApp.ViewModels
{
    class MainViewModel 
    {
        private RelayCommands _openManager, _openProducts, _openClients;

        public MainViewModel()
        {
            _openManager = new RelayCommands(OpenManagerWindow);
            _openProducts = new RelayCommands(OpenProdWindow);
            _openClients = new RelayCommands(OpenClientWindow);
        
        }
      
        public RelayCommands OpenManagerCommand => _openManager;
        public RelayCommands OpenProdCommand => _openProducts;
        public RelayCommands OpenClientsCommand => _openClients;

        //Метод открытия окна справочника менеджеров
        private void OpenManagerWindow()
        {
            ManagerWindow window = new ManagerWindow();
           
            window.Show();
        }



        //Метод откряти окна справочника продукции
        private void OpenProdWindow()
        {
            ProductWindow window = new ProductWindow();
            window.Show();
        }


        //Метод открытия справочника клиентов
        private void OpenClientWindow()
        {
            ClientWindow window = new ClientWindow();
            window.Show();
        }


    }
}
