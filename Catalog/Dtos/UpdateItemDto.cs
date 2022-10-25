using System.ComponentModel.DataAnnotations;

namespace Catalog.Dtos
{
    public record UpdateItemDto
    {
        [Required]
        public string ItemName { get; init; }
        [Required]
        [Range(1, 1000)]
        public decimal ItemPrice { get; init; }
    }
}
