using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Name = "Potatoes", Description="This is an item description.", Quantity = 5 },
                new Item { Id = Guid.NewGuid().ToString(), Name = "Chicken Breast", Description="This is an item description." , Quantity = 4},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Bag of Carrots", Description="This is an item description." , Quantity = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Orange Juice", Description="This is an item description." , Quantity = 1},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Bananas 5 Pack", Description="This is an item description." , Quantity = 4},
                new Item { Id = Guid.NewGuid().ToString(), Name = "Cookies (need better naming idea)", Description="This is an item description." , Quantity = 1}
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}