using Catalog.Dtos;
using Catalog.Entities;

namespace Catalog
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto{
                Id = item.Id,
                ItemName = item.Name,
                ItemPrice = item.Price,
                CreatedDate = item.CreatedDate
            };
        }
    }
}
