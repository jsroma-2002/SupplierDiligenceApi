using System.ComponentModel.DataAnnotations;

namespace SupplierDiligenceApi.Dtos
{
    public class SupplierUpdateDto
    {
        [StringLength(100)]
        public string? BusinessName { get; set; } // Razón social

        [StringLength(100)]
        public string? TradeName { get; set; } // Nombre comercial

        [StringLength(11, MinimumLength = 11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "La identificación tributaria debe tener exactamente 11 dígitos.")]
        public string? TaxId { get; set; } // Identificación tributaria

        [Phone]
        [StringLength(20)]
        public string? PhoneNumber { get; set; } // Número telefónico

        [EmailAddress]
        public string? Email { get; set; } // Correo electrónico

        [Url]
        public string? Website { get; set; } // Sitio web

        [StringLength(200)]
        public string? Address { get; set; } // Dirección física

        [StringLength(100)]
        public string? Country { get; set; } // País

        [Range(0, double.MaxValue, ErrorMessage = "La facturación anual debe ser un valor positivo.")]
        public decimal? AnnualRevenue { get; set; } // Facturación anual en dólares
    }
}
