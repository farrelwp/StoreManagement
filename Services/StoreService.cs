using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Data;
using StoreManagement.Models;
using StoreManagement.ViewModels;

namespace StoreManagement.Services
{
    public class StoreService : IStoreService
    {
        private AppDbContext _context;
        public StoreService(AppDbContext context)
        {
            _context = context;
        }
        public void AddStore(Store store)
        {
            _context.Stores.Add(store);
            _context.SaveChanges();
        }

        public void DeleteStore(int id)
        {
            Store storeToBeDeleted = GetSingleStoreById(id);
            _context.Stores.Remove(storeToBeDeleted);
            _context.SaveChanges();
        }

        public List<Store> GetAllStores()
        {
           return _context.Stores.ToList();
        }

        public Store GetSingleStoreById(int id) => _context.Stores.Where(n => n.Id == id).FirstOrDefault();

        public List<Branch> GetBranchesByStoreId(int storeId) => _context.Branches.Where(n => n.StoreId == storeId).ToList();
        

        public void UpdateStore(Store newStore)
        {
            Store oldStore = GetSingleStoreById(newStore.Id);
            oldStore.Address = newStore.Address;
            oldStore.FoundingYear = newStore.FoundingYear;
            oldStore.Name = newStore.Name;
            oldStore.NumberOfEmployees = newStore.NumberOfEmployees;
            _context.SaveChanges();
        }

        public StoreViewModel StoreDeletionConfirmation(int id)
        {

            Store store = GetSingleStoreById(id);
            StoreViewModel storeVM = new StoreViewModel()
            {
                Id = store.Id,
                StoreName = store.Name
            };

            return storeVM;

        }

        public StoreViewModel StoreDetails(int id)
        {
            Store store = GetSingleStoreById(id);
            StoreViewModel storeVM = new StoreViewModel()
            {
                StoreName = store.Name,
                Branches = GetBranchesByStoreId(id)
            };
            return storeVM;

        }
    }
}
