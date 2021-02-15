using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp.Data
{
    class ClientService
    {
        SoftTradePlusDBEntities db;
        public ClientService()
        {
            db = new SoftTradePlusDBEntities();
        }

        /// <summary>  
        /// Получение всех клиентов из БД и запись в коллекцию.  
        /// </summary> 
        public List<Client> GetAllClients()
        {
            List<Client> ClientList = new List<Client>();
            try
            {
                var SqlQuery = from obj in db.Clients
                               select obj;

                foreach (var client in SqlQuery)
                {
                    ClientList.Add(new Client
                    {
                        Id_cl = client.Id_cl,
                        Name_cl = client.Name_cl,
                        Type_cl = client.Type_cl,
                        Status_cl = client.Status_cl,
                        Manager = client.Manager,
                        Client_status = client.Client_status,
                        Manager1 = client.Manager1

                    });
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ClientList;
        }


        /// <summary>  
        /// Получение всех статусов из БД и запись в коллекцию.  
        /// </summary> 

        public List<Client_status> GetAllStatuses()
        {
            List<Client_status> StatusesList = new List<Client_status>();
            try
            {
                var SqlQuery = from obj in db.Client_status
                               select obj;
                foreach (var status in SqlQuery)
                {
                    StatusesList.Add(new Client_status { Id_status = status.Id_status, Status_cl = status.Status_cl});
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return StatusesList;

        }


        /// <summary>  
        /// Получение всей продукции по выбранному клиенту из БД и запись в коллекцию.  
        /// </summary> 
        public List<Product> GetProductsOfClient(Client CurrentClient)
        {
            List<Product> ProductsOfClient = new List<Product>();

            try
            {
                
                var SqlQuery = from p in db.Products
                           join cp in db.ClientsProducts on p.Id_prod equals cp.Product
                           where cp.Client == CurrentClient.Id_cl
                           select p;

                foreach (var product in SqlQuery)
                {
                    ProductsOfClient.Add(new Product
                    {
                        Id_prod = product.Id_prod,
                        Name_prod = product.Name_prod,
                        Price = product.Price,
                        Type_prod = product.Type_prod,
                        TimeLimit = product.TimeLimit
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ProductsOfClient;
        }


        
        public bool Add(Client newClient)
        {
            bool IsAdded = false;

            try
            {
                var client = new Client();

                client.Name_cl = newClient.Name_cl;
                client.Type_cl = newClient.Type_cl;
                client.Status_cl = newClient.Status_cl;
                client.Manager = newClient.Manager;
                client.Client_status = newClient.Client_status;
                client.Manager1 = newClient.Manager1;

                db.Clients.Add(client);
                var NoOfRowsAffected = db.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }
        public bool Update(Client clientBeforeUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var newClient = db.Clients.Find(clientBeforeUpdate.Id_cl);

                newClient.Name_cl = clientBeforeUpdate.Name_cl;
                newClient.Type_cl = clientBeforeUpdate.Type_cl;
                newClient.Status_cl = clientBeforeUpdate.Status_cl;
                newClient.Manager = clientBeforeUpdate.Manager;
                newClient.Client_status = clientBeforeUpdate.Client_status;
                newClient.Manager1 = clientBeforeUpdate.Manager1;

                var NoOfRowsAffected = db.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }
        public bool Delete(Client clientToDelete)
        {
            bool IsDeleted = false;
            try
            {
                var client = db.Clients.Find(clientToDelete.Id_cl);
                db.Clients.Remove(client);

                var NoOfRowsAffected = db.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsDeleted;
        }

    }
}
