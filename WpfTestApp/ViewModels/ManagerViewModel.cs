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
    class ManagerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ManagerService objManagerService;


        private RelayCommands _saveCommand, _updateCommand, _deleteCommand, _showCommand;

        private ObservableCollection<Manager> _managerList;
        private ObservableCollection<Client> _clientsOfManager;
        private Manager _currentManager;

        private string _message;

        public ManagerViewModel ()
        {
            objManagerService = new ManagerService();
            LoadData();
            CurrentManager = new Manager();
            _saveCommand = new RelayCommands(Save);
            _updateCommand = new RelayCommands(Update);
            _deleteCommand = new RelayCommands(Delete);
            _showCommand = new RelayCommands(ShowClients);
        }


        public ObservableCollection<Manager> ManagerList
        {
            get { return _managerList; }
            set { _managerList = value;
                  OnPropertyChanged("ManagerList"); }
        }
        public ObservableCollection<Client> ClientsOfManager
        {
            get { return _clientsOfManager; }
            set
            {
                _clientsOfManager = value;
                OnPropertyChanged("dgClientByMan");
            }
        }

        // Методы загрузки коллекции из БД.
        private void LoadData()
        {
            ManagerList = new ObservableCollection<Manager>(objManagerService.GetAllManagers());

        }

        
        public Manager CurrentManager
        {
            get { return _currentManager; }
            set { 
                  _currentManager = value;
                  OnPropertyChanged("CurrentManager"); 
            }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; 
                  OnPropertyChanged("Message"); }
        }


        public RelayCommands SaveManCommand => _saveCommand;

        public RelayCommands UpdateManCommand => _updateCommand;

        public RelayCommands DeleteManCommand => _deleteCommand;

        public RelayCommands ShowClientsCommand => _showCommand;

        /// <summary>  
        ///  Добавление нового менеджера в БД.  
        /// </summary>  
        public void Save()
        {
            try
            {
                var IsSaved = objManagerService.Add(CurrentManager);
                LoadData();

                if (IsSaved)
                    Message = "Менеджер успешно добавлен !";
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
                var IsUpdated = objManagerService.Update(CurrentManager);
                if (IsUpdated)
                {
                    Message = "Данные менеджера успешно изменены !";
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
                var IsDeleted = objManagerService.Delete(CurrentManager);
                if (IsDeleted)
                {
                    Message = "Менеджер удален !";
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


        /// <summary>  
        ///  Заполнение коллекции клиентов выбранного менеджера.  
        /// </summary> 
        public void ShowClients()
        {
            ClientsOfManager = new ObservableCollection<Client>(objManagerService.GetAllManagerClients(CurrentManager));

            Message = "Клиенты успешно отображены !";

        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}


