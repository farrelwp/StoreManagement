using StoreManagement.Models;
using StoreManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Services
{
    public interface IStoreService
    {
        List<Store> GetAllStores();
        void AddStore(Store store);
        Store GetSingleStoreById(int id);
        void UpdateStore(Store newStore);
        void DeleteStore(int id);
        List<Branch> GetBranchesByStoreId(int storeId);
        StoreViewModel StoreDeletionConfirmation(int id);
        StoreViewModel StoreDetails(int id);
        
    }
}
