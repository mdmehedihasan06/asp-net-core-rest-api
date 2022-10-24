using Catalog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Repositories
{
    public class InMemItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item { Id = System.Guid.NewGuid(), Name = "Potion", Price = 45, CreatedDate = System.DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Iron Shield", Price = 15, CreatedDate = System.DateTimeOffset.UtcNow },
            new Item { Id = System.Guid.NewGuid(), Name = "Bronze Shield", Price = 25, CreatedDate = System.DateTimeOffset.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItems(Guid id)
        {            
            return items.Where(m => m.Id == id).SingleOrDefault();
        }
    }
}