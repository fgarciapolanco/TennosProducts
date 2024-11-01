using System.ComponentModel.DataAnnotations;

namespace TennosProducts.Client.Models
{
    public class ProductoViewModel
    {
        [Key]
        public int ProductoID { get; set; }

        public string? Nombre { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }
    }
}
