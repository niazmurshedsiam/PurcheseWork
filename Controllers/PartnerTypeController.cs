using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;

namespace PurcheseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerTypeController : ControllerBase
    {
        private readonly IPartnerType _iPartnerType;
        public PartnerTypeController(IPartnerType iPartnerType)
        {
            _iPartnerType = iPartnerType;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<MessageHelper> Create(PartnerTypeDTO create)
        {
            return await _iPartnerType.Create(create);
        }
    }
}
