using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennosProducts.Core.Entities
{
    public class Productos 
    {
        [Key]
        public int ProductoID { get; set; }

        public string? Nombre { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaCreacion { get; set; }
    }

}
