using eFahionStore.Common.RequestViewModels.Catalog;
using eFahionStore.Common.RequestViewModels.WareHouses;
using eFashionStore.Model.Models.Catalogs;
using eFashionStore.Model.Models.WareHouses;
using eFashionStore.Service.Services.Catalogs;
using eFashionStore.Service.Services.WareHouses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.CatalogManage
{
    [Route("api/admin/warehouse/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private ISupplierService _supplierService;
        public SuppliersController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<Supplier>> GetAllSuppliers()
        {
            return await _supplierService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSupplier([FromForm] SupplierDto SupplierDto)
        {
            try
            {
                var supplier = new Supplier(0, SupplierDto.Name, SupplierDto.PhoneNumber, SupplierDto.Info, SupplierDto.Address,null,null);
                await _supplierService.Add(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, [FromForm] SupplierDto SupplierDto)
        {
            try
            {
                var supplier = new Supplier(id, SupplierDto.Name, SupplierDto.PhoneNumber, SupplierDto.Info, SupplierDto.Address, null, null);
                await _supplierService.Update(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            try
            {
                var supplier = await _supplierService.GetSingleAsyncById(id);
                await _supplierService.Delete(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
