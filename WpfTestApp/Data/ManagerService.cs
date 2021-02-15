using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp.Data
{
    class ManagerService 
    {
        SoftTradePlusDBEntities db;

        public ManagerService()
        {
            db = new SoftTradePlusDBEntities();
        }

        public List<Manager> GetAllManagers()
        {
            List<Manager> ManagerList = new List<Manager>();
            try
            {
                var SqlQuery = from obj in db.Managers
                               select obj;
                foreach (var manager in SqlQuery)
                {
                    ManagerList.Add(new Manager { Id_manager = manager.Id_manager , Name_manag = manager.Name_manag });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ManagerList;
        }

        public List<Client> GetAllManagerClients(Manager CurrentManager)
        {
            List<Client> ClientsOfManagerList = new List<Client>();
            try
            {
                var SqlQuery = db.Clients.Where(obj => obj.Manager == CurrentManager.Id_manager);

                foreach (var client in SqlQuery)
                {
                    ClientsOfManagerList.Add(new Client { Id_cl = client.Id_cl, 
                                                          Type_cl = client.Type_cl, 
                                                          Name_cl = client.Name_cl,
                                                          Status_cl = client.Status_cl, 
                                                          Manager = client.Manager,
                                                          Client_status = client.Client_status
                                                         });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ClientsOfManagerList;
        }
        public bool Add(Manager newManager)
        {
            bool IsAdded = false;
           
            try
            {
                var manager = new Manager();
                manager.Name_manag = newManager.Name_manag;


                db.Managers.Add(manager);
                var NoOfRowsAffected = db.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (SqlException ex)
            {

                throw ex;
            }

            return IsAdded;
        }

        public bool Update(Manager managerBeforeUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var newManager = db.Managers.Find(managerBeforeUpdate.Id_manager);
                newManager.Name_manag = managerBeforeUpdate.Name_manag;

                var NoOfRowsAffected = db.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }

        public bool Delete(Manager managerToDelete)
        {
            bool IsDeleted = false;
            try
            {
                var manager = db.Managers.Find(managerToDelete.Id_manager);
                db.Managers.Remove(manager);

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
