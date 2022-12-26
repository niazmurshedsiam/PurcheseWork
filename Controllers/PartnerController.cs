using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;

namespace PurcheseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartner _iPartner;
        public PartnerController(IPartner iPartner)
        {
            _iPartner = iPartner;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<MessageHelper> Create(PartnerDTO create)
        {
            return await _iPartner.Create(create);
        }
    }
}
