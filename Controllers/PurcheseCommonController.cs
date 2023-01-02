using Microsoft.AspNetCore.Http;
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

        [HttpPost]
        [Route("CreateItems")]
        public async Task<IActionResult> CreateItems(List<ItemsViewModel> createlist)
        {

            return Ok(await _iPurcheseCommon.CreateItems(createlist));

        }

        [HttpGet]
        [Route("GetItems")]
        public async Task<List<GetItemsViewModel>> GetItems(int IntItemId)
        {
            return await _iPurcheseCommon.GetItems(IntItemId);

        }
        [HttpPut]
        [Route("EditItem")]
        public async Task<MessageHelper> Edit(List<EditItemsViewModel> editlist)
        {
            return await _iPurcheseCommon.EditItem(editlist);
        }

        //[HttpPost]
        //[Route("PurchasesCreate")]
        //public async Task<MessageHelper> CreatePurchase(PurchasesViewModel create)
        //{

        //    return await _iPurcheseCommon.CreatePurchase(create);
        //}
      
        //public async Task<IActionResult> CreatePurchaseDetails(PurchaseDetailViewModel create)
        //{

        //    return Ok(await _iPurcheseCommon.CreatePurchaseDetails(create));
        //}
        [HttpPost]
        [Route("PurchasesDetailsCreate")]
        public async Task<MessageHelper> CreatePurchase(PurchaseCommonVM create)
        {
            return await _iPurcheseCommon.CreatePurchase(create);
        }
        [HttpPost]
        [Route("SalesDetailsCreate")]
        public async Task<MessageHelper> CreateSales(SalesCommonViewModel create)
        {
            return await _iPurcheseCommon.CreateSales(create);
        }

        [HttpPost]
        [Route("GetItemWiseDailyPurchase")]
        public async Task<List<getDailyPurchanseReportViewModel>>getDailyPurchanseReportViewModel(DateTime dalilyPurchanseReport)
        {

            return await _iPurcheseCommon.getDailyPurchanseReportViewModel(dalilyPurchanseReport);

        }

        [HttpPost]
        [Route("GetItemWiseMonthSales")]
        public async Task<List<getMonthSalesReportViewModel>> GetMonthSalesReportViewModels(int Month,int Year)
        {
            return await _iPurcheseCommon.getMonthSalesReportViewModel(Month,Year);
        }

        [HttpPost]
        [Route("getItemWiseDailyPurchaseVsSalesReports")]
        public async Task<List<getItemWiseDailyPurchaseVsSalesReport>> getItemWiseDailyPurchaseVsSalesReports(DateTime DailyPurchaseVsSalesReportDate)
        {
            return await _iPurcheseCommon.getItemWiseDailyPurchaseVsSalesReports(DailyPurchaseVsSalesReportDate);
        }

        [HttpPost]
        [Route("getItemReportWithGivenColumnReport")]
        public async Task<List<getItemReportWithGivenColumnReport>> getItemReportWithGivenColumnReport()
        {
            return await _iPurcheseCommon.getItemReportWithGivenColumnReport();
        }




    }
}
