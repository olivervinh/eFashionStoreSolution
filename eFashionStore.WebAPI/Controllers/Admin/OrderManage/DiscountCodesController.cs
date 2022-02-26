using eFahionStore.Common.Helpers;
using eFahionStore.Common.RequestViewModels.Order;
using eFashionStore.Model.Models.Orders;
using eFashionStore.Service.Services.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eFashionStore.WebAPI.Controllers.Admin.OrderManage
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCodesController : ControllerBase
    {
        private IDiscountCodeService _discountCodeService;
        public DiscountCodesController(IDiscountCodeService discountCodeService)
        {
            _discountCodeService = discountCodeService;
        }
        [HttpGet("GetAll")]
        public async Task<IEnumerable<DiscountCode>> GetAllDiscountCodes()
        {
            return await _discountCodeService.GetAllAsync();
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCode([FromForm] DiscountCodeDto DiscountCodeDto)
        {
            try
            {
                var discountCode = new DiscountCode(0,RandomStringHelper.RandomString(5), DiscountCodeDto.ValueDiscountPrice);
                await _discountCodeService.Add(discountCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDiscountCode(int id, [FromForm] DiscountCodeDto DiscountCodeDto)
        {
            try
            {
                var discountCode = new DiscountCode(id, RandomStringHelper.RandomString(5), DiscountCodeDto.ValueDiscountPrice);
                await _discountCodeService.Update(discountCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCode(int id)
        {
            try
            {
                var DiscountCode = await _discountCodeService.GetSingleAsyncById(id);
                await _discountCodeService.Delete(DiscountCode);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
