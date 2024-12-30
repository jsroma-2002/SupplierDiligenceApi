using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SupplierDiligenceApi.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string BusinessName { get; set; } // Razón social

        [Required]
        [StringLength(100)]
        public string TradeName { get; set; } // Nombre comercial

        [Required]
        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "La identificación tributaria debe tener exactamente 11 dígitos.")]
        public string TaxId { get; set; } // Identificación tributaria

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; } // Número telefónico

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Correo electrónico

        [Required]
        [Url]
        public string Website { get; set; } // Sitio web

        [Required]
        [StringLength(200)]
        public string Address { get; set; } // Dirección física

        [Required]
        [StringLength(100)]
        public string Country { get; set; } // País


        [Required]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "La facturación anual debe ser un valor positivo.")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AnnualRevenue { get; set; } // Facturación anual en dólares

        public DateTime LastEdited { get; set; } // Fecha de última edición

        // Constructor opcional para inicializar valores predeterminados
        public Supplier() => LastEdited = DateTime.Now;
    }
}
