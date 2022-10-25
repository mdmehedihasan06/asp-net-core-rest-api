using System;

namespace Catalog.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public string ItemName { get; init; }
        public decimal ItemPrice { get; init; }
        public DateTimeOffset CreatedDate { get; init; }
    }
}
