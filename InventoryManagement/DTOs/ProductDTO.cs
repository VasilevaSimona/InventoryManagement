using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
        [Range(0, int.MaxValue)]
        public int QuantityInStock { get; set; }
        public string? Category { get; set; }
        public string? ImageBase64 { get; set; }
    }
}
