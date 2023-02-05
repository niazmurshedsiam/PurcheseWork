using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.DTO
{
    public class CommonDTO
    {
        public class PartnerViewModel
        {
            public string? StrPartnerName { get; set; }

            public int? IntPartnerTypeId { get; set; }

            public bool? IsActive { get; set; }
        }
        public class PartnerTypeViewModel
        {
            
            public string? StrPartnerTypeName { get; set; }
            public bool? IsActive { get; set; }
        }

        public class ItemsViewModel
        {
            
            public string? StrItemName { get; set; }
            public decimal? NumStockQuantity { get; set; }
            public bool? IsActive { get; set; }
        }
        public class GetItemsViewModel
        {
            public int IntItemId { get; set; }
            public string? StrItemName { get; set; }
            public decimal? NumStockQuantity { get; set; }
        }
        
        public class EditItemsViewModel
        {
            public int IntItemId { get; set; }
            public string? StrItemName { get; set; }
            public decimal? NumStockQuantity { get; set; }
        }

        public class PurchasesViewModel
        {
            
            public int? SupplierId { get; set; }
            
            public DateTime? PurchaseDate { get; set; }
            
            public bool? IsActive { get; set; }
        }
        public class PurchaseCommonVM
        {
            public PurchasesViewModel? header { get; set; }
            public List<PurchaseDetailViewModel>? details { get; set; }
        }
        public  class PurchaseDetailViewModel
        {
            
            public int? IntPurchaseId { get; set; }
            
            public int? IntItemId { get; set; }
            
            public decimal? NumItemQuantity { get; set; }
            
            public decimal? NumUnitPrice { get; set; }
            
            public bool? IsActive { get; set; }
        }




        public class SaleViewModel
        {
            public int? CustomerId { get; set; }

            public DateTime? SalesDate { get; set; }

            public bool? IsActive { get; set; }
        }

        public class SalesCommonViewModel
        {
            public SaleViewModel? header { get; set;}
            public List<SalesDetailsViewModel>? details { get; set; } 

        }
        public class SalesDetailsViewModel
        {
            public int? SalesId { get; set; }
           
            public int? ItemId { get; set; }
            
            public decimal? ItemQuantity { get; set; }
            
            public decimal? UnitPrice { get; set; }
            
            public bool? IsActive { get; set; }
        }
        public class getDailyPurchanseReportViewModel
        {
            

            public int? ItemId { get; set; }
            public string? ItemName { get; set; }

            public decimal? TotalQuantity { get; set; }

           
            public decimal? TotalPrice { get; set; }
        }

        public class getMonthSalesReportViewModel
        {
            
            public int? ItemId { get; set; }
            public string? ItemName { get; set; }

            public decimal? TotalSalQuantity { get; set; }


            public decimal? TotalSalPrice { get; set; }
        }

        public class getItemWiseDailyPurchaseVsSalesReport
        {
            public int? ItemId { get; set; }
            public string? ItemName { get; set; }

            public decimal? TotalPurQuantity { get; set; } 
            public decimal? TotalPurPrice { get; set; }
            public decimal? TotalSalQuantity { get; set; }
            public decimal? TotalSalPrice { get; set; }
            getDailyPurchanseReportViewModel? getDailyPurchanseReportViewModel { get; set; }
            getMonthSalesReportViewModel? getMonthSalesReportViewModel { get; set; }
           

        }

        public class purchaseModelView
        {
            public DateTime? DtePurchaseDate { get; set; }
            public decimal? NumItemQuantity { get; set; }
            public decimal? NumUnitPrice { get; set; }
            public decimal? TotalPurPrice { get; set; }
            public int? Month { get; set; }
            public int? Year { get; set; }
        }

        public class SalesModelViewdel
        {
            public DateTime? DtePurchaseDate { get; set; }
            public decimal? NumItemQuantity { get; set; }
            public decimal? NumUnitPrice { get; set; }
            public decimal? TotalSalPrice { get; set; }
            public int? Month { get; set; }
            public int? year { get; set; }
            


        }

        public class getItemReportWithGivenColumnReport
        {
           
            public int? Month { get; set; }
            public int? Year { get; set; }

            public decimal? TotalPurPrice { get; set; }
            public decimal? TotalSalPrice { get; set; }
            public string? status { get; set; }
            purchaseModelView? purchaseModelView { get; set; }

            SalesModelViewdel? SalesModelViewdel { get; set; }
        }
    }
}
