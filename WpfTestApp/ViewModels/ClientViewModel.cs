using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTestApp.Commands;
using WpfTestApp.Data;

namespace WpfTestApp.ViewModels
{
    class ClientViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        ClientService objClientService;
        ManagerService objManagerService;

        private RelayCommands _saveCommand, _updateCommand, _deleteCommand, _showCommand;

        private ObservableCollection<Client> _clientList;
        private ObservableCollection<Product> _productsOfClient;
        private ObservableCollection<Manager> _managerList;
        private ObservableCollection<Client_status> _statusList;

        private Client _currentClient;
        private string _message;

        public ClientViewModel()
        {

            objClientService = new ClientService();
            objManagerService = new ManagerService();
            LoadData();
            CurrentClient = new Client();
            _saveCommand = new RelayCommands(Save);
            _updateCommand = new RelayCommands(Update);
            _deleteCommand = new RelayCommands(Delete);
            _showCommand = new RelayCommands(ShowProducts);

        }


        public ObservableCollection<Client> ClientList
        {
            get { return _clientList; }
            set
            {
                _clientList = value;
                OnPropertyChanged("ClientList");
            }
        }

        public ObservableCollection<Product> ProductsOfClient
        {
            get { return _productsOfClient; }
            set
            {
                _productsOfClient = value;
                OnPropertyChanged("dgProdOfClient");
            }
        }

        public ObservableCollection<Manager> ManagerList
        {
            get { return _managerList; }
            set
            {
                _managerList = value;
                OnPropertyChanged("ManagerList");
            }
        }

        public ObservableCollection<Client_status> StatusList
        {
            get { return _statusList; }
            set
            {
                _statusList = value;
                OnPropertyChanged("StatusList");
            }
        }

        private void LoadData()
        {
            ClientList = new ObservableCollection<Client>(objClientService.GetAllClients());
            StatusList = new ObservableCollection<Client_status>(objClientService.GetAllStatuses());
            ManagerList = new ObservableCollection<Manager>(objManagerService.GetAllManagers());

        }
     
        public Client CurrentClient
        {
            get { return _currentClient; }
            set
            {
                _currentClient = value;
                OnPropertyChanged("CurrentClient");
            }
        }



        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }


        public RelayCommands SaveClCommand => _saveCommand;
        public RelayCommands UpdateClCommand => _updateCommand;
        public RelayCommands DeleteClCommand => _deleteCommand;
        public RelayCommands ShowProductsCommand => _showCommand;

      
        public void Save()
        {
            try
            {
                var IsSaved = objClientService.Add(CurrentClient);
                LoadData();

                if (IsSaved)
                    Message = "Клиент успешно добавлен !";
                else
                    Message = "Ошибка добавления !";

            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void Update()
        {
            try
            {
                var IsUpdated = objClientService.Update(CurrentClient);
                if (IsUpdated)
                {
                    Message = "Данные клиента успешно изменены !";
                    LoadData();
                }
                else
                {
                    Message = "Ошибка операции изменения !";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void Delete()
        {
            try
            {
                var IsDeleted = objClientService.Delete(CurrentClient);
                if (IsDeleted)
                {
                    Message = "Клиент удален !";
                    LoadData();
                }
                else
                {
                    Message = "Ошибка операции удаления !";
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
            }
        }

        public void ShowProducts()
        {
            ProductsOfClient = new ObservableCollection<Product>(objClientService.GetProductsOfClient(CurrentClient));

            Message = "Продукты клиента успешно отображены !";

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
