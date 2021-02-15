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
    class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        ProductService objProdService;

        private RelayCommands _saveCommand, _updateCommand, _deleteCommand;
        private string _message;

        private ObservableCollection<Product> _productList;

        private Product _currentProduct;

        public ProductViewModel()
        {

            objProdService = new ProductService();
            LoadData();
            CurrentProduct = new Product();
            _saveCommand = new RelayCommands(Save);
            _updateCommand = new RelayCommands(Update);
            _deleteCommand = new RelayCommands(Delete);
        }

        public ObservableCollection<Product> ProductList
        {
            get { return _productList; }
            set
            {
                _productList = value;
                OnPropertyChanged("ProductList");
            }
        }


        private void LoadData()
        {
            ProductList = new ObservableCollection<Product>(objProdService.GetAllProducts());

        }


        public Product CurrentProduct
        {
            get { return _currentProduct; }
            set
            {
                _currentProduct = value;
                OnPropertyChanged("CurrentProduct");
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


        public RelayCommands SaveProdCommand => _saveCommand;
        public RelayCommands UpdateProdCommand => _updateCommand;
        public RelayCommands DeleteProdCommand => _deleteCommand;

        public void Save()
        {
            try
            {
                var IsSaved = objProdService.Add(CurrentProduct);
                LoadData();

                if (IsSaved)
                    Message = "Продукт успешно добавлен !";
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
                var IsUpdated = objProdService.Update(CurrentProduct);
                if (IsUpdated)
                {
                    Message = "Данные продукта успешно изменены !";
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
                var IsDeleted = objProdService.Delete(CurrentProduct);
                
                if (IsDeleted)
                {
                    Message = "Продукт удален !";
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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
