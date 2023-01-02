using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Models;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.Interface
{
    public interface IPurcheseCommon
    {
        public  Task<MessageHelper> CreatePartnerType(PartnerTypeViewModel create);
        public Task<MessageHelper> CreatePartner(PartnerViewModel create);
        public Task<MessageHelper> CreateItems(List<ItemsViewModel> createlist);
        public Task<List<GetItemsViewModel>> GetItems(int IntItemId);
        public Task<MessageHelper> EditItem(List<EditItemsViewModel> edit);
        public Task<MessageHelper> CreatePurchase(PurchaseCommonVM create);
        public Task<MessageHelper> CreateSales(SalesCommonViewModel create);
        public Task<List<getDailyPurchanseReportViewModel>> getDailyPurchanseReportViewModel(DateTime dalilyPurchanseReport);
        public Task<List<getMonthSalesReportViewModel>> getMonthSalesReportViewModel(int Month,int Year);

        public Task<List<getItemWiseDailyPurchaseVsSalesReport>> getItemWiseDailyPurchaseVsSalesReports(DateTime DailyPurchaseVsSalesReportDate);

        public Task<List<getItemReportWithGivenColumnReport>> getItemReportWithGivenColumnReport();

    }
}
