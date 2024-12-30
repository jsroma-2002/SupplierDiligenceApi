using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplierDiligenceApi.Data;
using SupplierDiligenceApi.Dtos;
using SupplierDiligenceApi.Models;

namespace SupplierDiligenceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly SupplierContext _context;

        public SuppliersController(SupplierContext context)
        {
            _context = context;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult> GetSuppliers([FromQuery] int page = 1, [FromQuery] int perPage = 5) {
            try
            {
                var totalItems = await _context.Suppliers.CountAsync();
                var totalPages = (int)Math.Ceiling(totalItems / (double)perPage);

                var suppliers = await _context.Suppliers
                    .OrderByDescending(s => s.LastEdited)
                    .Skip((page - 1) * perPage)
                    .Take(perPage)
                    .ToListAsync();

                var response = new
                {
                    page,
                    perPage,
                    totalPages,
                    totalItems,
                    items = suppliers
                };

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving suppliers.", details = ex.Message });
            }
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier;
        }

        // POST: api/Suppliers
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier([FromBody] SupplierCreateDto supplierDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplier = new Supplier
            {
                BusinessName = supplierDto.BusinessName,
                TradeName = supplierDto.TradeName,
                TaxId = supplierDto.TaxId,
                PhoneNumber = supplierDto.PhoneNumber,
                Email = supplierDto.Email,
                Website = supplierDto.Website,
                Address = supplierDto.Address,
                Country = supplierDto.Country,
                AnnualRevenue = supplierDto.AnnualRevenue,
                LastEdited = DateTime.Now
            };

            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSupplier), new { id = supplier.Id }, supplier);
        }

        // PUT: api/Suppliers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplier(int id, [FromBody] SupplierUpdateDto supplierDto)
        {

            var supplier = await _context.Suppliers.FindAsync(id);

            if (supplier == null)
                return NotFound("Proveedor no encontrado.");

            if (supplierDto.BusinessName != null)
                supplier.BusinessName = supplierDto.BusinessName;

            if (supplierDto.TradeName != null)
                supplier.TradeName = supplierDto.TradeName;

            if (supplierDto.TaxId != null)
                supplier.TaxId = supplierDto.TaxId;

            if (supplierDto.PhoneNumber != null)
                supplier.PhoneNumber = supplierDto.PhoneNumber;

            if (supplierDto.Email != null)
                supplier.Email = supplierDto.Email;

            if (supplierDto.Website != null)
                supplier.Website = supplierDto.Website;

            if (supplierDto.Address != null)
                supplier.Address = supplierDto.Address;

            if (supplierDto.Country != null)
                supplier.Country = supplierDto.Country;

            if (supplierDto.AnnualRevenue.HasValue)
                supplier.AnnualRevenue = supplierDto.AnnualRevenue.Value;

            supplier.LastEdited = DateTime.Now;

            _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();

            // Return the updated supplier
            return Ok(supplier);
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplier);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

