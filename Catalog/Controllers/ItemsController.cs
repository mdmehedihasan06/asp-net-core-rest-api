using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository repository;
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }
        // GET/items
        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select(item => item.AsDto());
            return items;
        }
        // GET/items/{id}
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id).AsDto();
            if (item is null)
            {
                return NotFound();
            }
            return item;
        }
        // POST/items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.ItemName,
                Price = itemDto.ItemPrice,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item.AsDto());
        }
        // POST/items/{id}
        [HttpPut("{id}")]
        public ActionResult<ItemDto> UpdateItem(Guid id,UpdateItemDto itemDto)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem == null)
            {
                return NotFound();
            }
            Item updateItem = existingItem with
            {
                Name = itemDto.ItemName,
                Price = itemDto.ItemPrice
            };
            repository.UpdateItem(updateItem);
            return NoContent();
        }
        // DELETE/items/{id}
        [HttpDelete("{id}")]
        public ActionResult<ItemDto> DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);
            if (existingItem == null)
            {
                return NotFound();
            }            
            repository.DeleteItem(id);
            return NoContent();
        }
    }
}
