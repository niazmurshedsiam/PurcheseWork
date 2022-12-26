﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurcheseCommonController : ControllerBase
    {
        private readonly IPurcheseCommon _iPurcheseCommon;
        public PurcheseCommonController(IPurcheseCommon iPurcheseCommon)
        {
            _iPurcheseCommon = iPurcheseCommon;
        }
        [HttpPost]
        [Route("PartnerTypeCreate")]
        public async Task<IActionResult> PartnerTypeCreate(PartnerTypeViewModel create)
        {

            return Ok(await _iPurcheseCommon.CreatePartnerType(create));
        }

        [HttpPost]
        [Route("PartnerCreate")]
        public async Task<IActionResult> PartnerCreate(PartnerViewModel create)
        {

            return Ok(await _iPurcheseCommon.CreatePartner(create));
        }
    }
}