using System.ComponentModel.DataAnnotations;

namespace SupplierDiligenceApi.Dtos
{
    public class SupplierCreateDto
    {
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
        [Range(0, double.MaxValue, ErrorMessage = "La facturación anual debe ser un valor positivo.")]
        public decimal AnnualRevenue { get; set; } // Facturación anual en dólares
    }
}
