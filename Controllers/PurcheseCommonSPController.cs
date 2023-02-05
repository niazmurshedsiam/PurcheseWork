using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurcheseWork.Helper;
using PurcheseWork.Interface;
using PurcheseWork.Repository;
using PurcheseWork.StoreProcedurce;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurcheseCommonSPController : ControllerBase
    {
        private readonly PurcheseSpCommon _iPurcheseCommonSP = new PurcheseSpCommon();

        [HttpPost]
        [Route("EmployeeCreateUpdate")]
        public async Task<IActionResult> EmployeeCreate(PartnerViewModel obj)
        {
            var dt = await _iPurcheseCommonSP.EmployeeCreate(obj);
            return Ok(dt);
        }
    }
}
