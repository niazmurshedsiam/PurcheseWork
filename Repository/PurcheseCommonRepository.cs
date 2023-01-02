using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PurcheseWork.DbContexts;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;
using PurcheseWork.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.Repository
{
    public class PurcheseCommonRepository : IPurcheseCommon
    {
        private readonly AppDbContext _context;
        public PurcheseCommonRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<MessageHelper> CreateItems(List<ItemsViewModel> createlist)
        {
            int count = 0;
            List<TblItem> duplicateList = new List<TblItem>();
            try
            {
                List<TblItem> newitemList = new List<TblItem>();

                string msg = "";
                //msg = msg + $"AlReady Exist Item Count: {count}" + " ";
                foreach (var item in createlist)
                {
                    var DuplicateValue = _context.TblItems.Where(x => x.StrItemName.ToLower() == item.StrItemName.ToLower() && x.IsActive == true)
                        .Select(a => a).FirstOrDefault();
                    if (DuplicateValue != null)
                    {

                        msg = msg + item.StrItemName + ",";
                        count++;
                        var data1 = new Models.TblItem()
                        {
                            StrItemName = item.StrItemName,
                            NumStockQuantity = item.NumStockQuantity,
                            IsActive = true,
                        };
                        duplicateList.Add(data1);

                    }

                    //if (count > 0)
                    //{
                    //    string msg = "";
                    //    msg = msg + $"AlReady Exist Item Count: {count}" + " ";
                    //    duplicateList.ForEach(x =>
                    //    {
                    //        msg = msg + x.StrItemName + ",";
                    //    });
                    //    throw new Exception($"{msg}");
                    //}
                    var data = new Models.TblItem()
                    {
                        StrItemName = item.StrItemName,
                        NumStockQuantity = item.NumStockQuantity,
                        IsActive = true,
                    };
                    newitemList.Add(data);
                }
                msg = msg + $"AlReady Exist Item Count: {count}" + " ";

                if (count > 0)
                {

                    //msg = msg + $"AlReady Exist Item Count: {count}" + " ";


                    msg = msg.Remove(msg.Length - 1);
                    throw new Exception($"{msg}");

                }
                await _context.TblItems.AddRangeAsync(newitemList);
                await _context.SaveChangesAsync();

                return new MessageHelper()
                {

                    Message = "Successfully create",
                    statuscode = 200,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> CreatePartner(PartnerViewModel create)
        {
            try
            {
                var data = new Models.TblPartner()
                {
                    StrPartnerName = create.StrPartnerName,
                    IntPartnerTypeId = create.IntPartnerTypeId,
                    IsActive = create.IsActive,
                };
                await _context.TblPartners.AddAsync(data);
                await _context.SaveChangesAsync();
                return new MessageHelper()
                {

                    Message = "Successfully create",
                    statuscode = 200,
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> CreatePartnerType(PartnerTypeViewModel create)
        {
            try
            {

                var data = new Models.TblPartnerType()
                {
                    StrPartnerTypeName = create.StrPartnerTypeName,
                    IsActive = true,
                };
                await _context.TblPartnerTypes.AddAsync(data);
                await _context.SaveChangesAsync();
                return new MessageHelper()
                {
                    Message = "Create Successfully",
                    statuscode = 200
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<GetItemsViewModel>> GetItems(int IntItemId)
        {
            try
            {
                var data = _context.TblItems.Where(x => x.IntItemId == IntItemId || IntItemId == 0)
                                                            .Select(a => new GetItemsViewModel()
                                                            {
                                                                IntItemId = a.IntItemId,
                                                                StrItemName = a.StrItemName,
                                                                NumStockQuantity = a.NumStockQuantity,

                                                            }
                                                            ).ToList();

                return data;
            }
            catch (Exception)
            {

                throw;
            }
        }
        //public async Task<MessageHelper> EditItems(List<EditItemsViewModel> editlist)
        //{
        //    try
        //    {
        //        List<TblItem> newObjList = new List<TblItem>();
        //        foreach (var item in editlist)
        //        {
        //            var data = _context.TblItems.Where(x => x.IntItemId == item.IntItemId)
        //                                         .Select(a => a).FirstOrDefault();
        //            data.StrItemName = item.StrItemName;
        //            data.NumStockQuantity = (int)item.NumStockQuantity;
        //            newObjList.Add(data);
        //        }
        //        _context.TblItems.UpdateRange(newObjList);
        //        await _context.SaveChangesAsync();
        //        return new MessageHelper()
        //        {

        //            Message = "Successfully Update",
        //            statuscode = 200,
        //        };
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

        public async Task<MessageHelper> EditItem(List<EditItemsViewModel> editlist)
        {
            try
            {


                List<TblItem> newObjList = new List<TblItem>();
                foreach (var item in editlist)
                {
                    var DuplicateValue = _context.TblItems.Where(x =>/*x.IntItemId != item.IntItemId &&*/  x.StrItemName.ToLower() == item.StrItemName.ToLower() && x.IsActive == true)
                        .Select(a => a).FirstOrDefault();
                    if (DuplicateValue != null)
                    {
                        throw new Exception($"{item.StrItemName} Name Already Exits");
                    }
                    var data = _context.TblItems.Where(x => x.IntItemId == item.IntItemId)
                                                 .Select(a => a).FirstOrDefault();
                    data.StrItemName = item.StrItemName;
                    data.NumStockQuantity = (int)item.NumStockQuantity;
                    newObjList.Add(data);
                }
                _context.TblItems.UpdateRange(newObjList);
                await _context.SaveChangesAsync();
                return new MessageHelper()
                {

                    Message = "Successfully Update",
                    statuscode = 200,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> CreatePurchase(PurchasesViewModel create)
        {
            try
            {
                var data = new Models.TblPurchase()
                {
                    IntSupplierId = create.SupplierId,
                    DtePurchaseDate = create.PurchaseDate,
                    IsActive = true

                };
                await _context.TblPurchases.AddAsync(data);
                await _context.SaveChangesAsync();
                return new MessageHelper()
                {

                    Message = "Create Successfully",
                    statuscode = 200,

                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MessageHelper> CreatePurchase(PurchaseCommonVM create)
        {
            try
            {
                TblPurchase head = new TblPurchase()
                {
                    IntSupplierId = create.header.SupplierId,
                    DtePurchaseDate = DateTime.Now,
                    IsActive = true
                };
                await _context.TblPurchases.AddAsync(head);
                await _context.SaveChangesAsync();

                List<TblPurchaseDetail> tblPurchaseDetail = new List<TblPurchaseDetail>();
                foreach (var item in create.details)
                {
                    var PurchesitemList = new TblPurchaseDetail()
                    {
                        IntItemId = item.IntItemId,
                        IntPurchaseId = head.IntPurchaseId,
                        NumItemQuantity = item.NumItemQuantity,
                        NumUnitPrice = item.NumUnitPrice,
                        IsActive = true
                    };
                    tblPurchaseDetail.Add(PurchesitemList);
                }

                await _context.AddRangeAsync(tblPurchaseDetail);
                await _context.SaveChangesAsync();

                return new MessageHelper()
                {
                    Message = "Create Successfully",
                    statuscode = 200,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MessageHelper> CreateSales(SalesCommonViewModel create)
        {
            try
            {
                long count = 0;
                foreach (var itm in create.details)
                {
                    var x = await _context.TblItems.Where(x => x.IntItemId == itm.ItemId
                                                               && x.IsActive == true
                                                               && itm.ItemQuantity > x.NumStockQuantity)
                                                        .FirstOrDefaultAsync();
                    if (x != null)
                    {
                        count++;
                    }
                }
                if (count == create.details.Count())
                {
                    throw new Exception("You can not sales anything from here");
                }

                TblSale sales = new TblSale()
                {

                    IntCustomerId = create.header.CustomerId,
                    DteSalesDate = DateTime.Now,
                    IsActive = true

                };


                await _context.TblSales.AddAsync(sales);
                await _context.SaveChangesAsync();

                List<TblSalesDetail> salesDetailsList = new List<TblSalesDetail>();
                foreach (var item in create.details)
                {
                    var quantity = await (from i in _context.TblItems
                                          where i.IntItemId == item.ItemId && i.IsActive == true
                                          select i).FirstOrDefaultAsync();

                    if (item.ItemQuantity > quantity.NumStockQuantity)
                    {

                        continue;
                    }
                    var salesDetail = new TblSalesDetail()
                    {
                        IntSalesId = sales.IntSalesId,
                        IntItemId = item.ItemId,
                        NumItemQuantity = item.ItemQuantity,
                        NumUnitPrice = item.UnitPrice,
                        IsActive = true
                    };
                    salesDetailsList.Add(salesDetail);

                }
                await _context.TblSalesDetails.AddRangeAsync(salesDetailsList);
                await _context.SaveChangesAsync();


                return new MessageHelper()
                {

                    Message = "Save SuccessFully",
                    statuscode = 200
                };

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<getDailyPurchanseReportViewModel>> getDailyPurchanseReportViewModel(DateTime dalilyPurchanseReport)
        {
            try
            {
                List<getDailyPurchanseReportViewModel> PurchanseReport = await Task.FromResult((from pur in _context.TblPurchases
                                                                                                join
                                                                                                purd in _context.TblPurchaseDetails
                                                                                                on pur.IntPurchaseId equals purd.IntPurchaseId
                                                                                                join itm in _context.TblItems on
                                                                                                 purd.IntItemId equals itm.IntItemId
                                                                                                where (pur.DtePurchaseDate.Value.Date == dalilyPurchanseReport.Date)
                                                                                                group new { purd, itm } by new { purd.IntItemId, itm.StrItemName } into g
                                                                                                select new getDailyPurchanseReportViewModel
                                                                                                {

                                                                                                    ItemId = g.Key.IntItemId,
                                                                                                    ItemName = g.Key.StrItemName,
                                                                                                    TotalQuantity = g.Sum(s => s.purd.NumItemQuantity),
                                                                                                    TotalPrice = g.Sum(s => s.purd.NumUnitPrice * s.purd.NumItemQuantity)
                                                                                                }).ToList());
                return PurchanseReport;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<List<getMonthSalesReportViewModel>> getMonthSalesReportViewModel(int Month, int Year)
        {
            try
            {
                var SalesReport = await Task.FromResult((from sal in _context.TblSales
                                                         join
                                                         salDel in _context.TblSalesDetails
                                                         on sal.IntSalesId equals salDel.IntSalesId
                                                         join
                                                         itm in _context.TblItems
                                                         on salDel.IntItemId equals itm.IntItemId

                                                         where (sal.DteSalesDate.Value.Month == Month
                                                         && sal.DteSalesDate.Value.Year == Year)
                                                         group new { salDel, itm } by new { itm.StrItemName, salDel.IntItemId } into g
                                                         select new getMonthSalesReportViewModel
                                                         {
                                                             ItemId = g.Key.IntItemId,
                                                             ItemName = g.Key.StrItemName,
                                                             TotalSalQuantity = g.Sum(s => s.salDel.NumItemQuantity),
                                                             TotalSalPrice = g.Sum(s => s.salDel.NumUnitPrice * s.salDel.NumItemQuantity)

                                                         }).ToList());
                return SalesReport;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<getItemWiseDailyPurchaseVsSalesReport>> getItemWiseDailyPurchaseVsSalesReports(DateTime DailyPurchaseVsSalesReportDate)
        {

            var PurchaseReport = await Task.FromResult(from pur in _context.TblPurchases
                                                       join purDel in _context.TblPurchaseDetails on pur.IntPurchaseId equals purDel.IntPurchaseId
                                                       join itm in _context.TblItems on purDel.IntItemId equals itm.IntItemId
                                                       where (pur.DtePurchaseDate.Value.Date == DailyPurchaseVsSalesReportDate.Date)
                                                       group new { purDel, itm } by new { itm.StrItemName, purDel.IntItemId } into g
                                                       select new getDailyPurchanseReportViewModel
                                                       {
                                                           ItemId = g.Key.IntItemId,
                                                           ItemName = g.Key.StrItemName,
                                                           TotalQuantity = g.Sum(s => s.purDel.NumItemQuantity),
                                                           TotalPrice = g.Sum(s => s.purDel.NumUnitPrice * s.purDel.NumUnitPrice)
                                                       });

            var SalesReport = await Task.FromResult(from sal in _context.TblSales
                                                    join salDel in _context.TblSalesDetails on sal.IntSalesId equals salDel.IntSalesId
                                                    join itm in _context.TblItems on salDel.IntItemId equals itm.IntItemId
                                                    where (sal.DteSalesDate.Value.Date == DailyPurchaseVsSalesReportDate.Date)
                                                    group new { salDel, itm } by new { itm.StrItemName, sal.IntSalesId } into g
                                                    select new getMonthSalesReportViewModel
                                                    {
                                                        ItemId = g.Key.IntSalesId,
                                                        ItemName = g.Key.StrItemName,
                                                        TotalSalQuantity = g.Sum(s => s.salDel.NumItemQuantity),
                                                        TotalSalPrice = g.Sum(s => s.salDel.NumUnitPrice * s.salDel.NumItemQuantity)
                                                    });


            List<getItemWiseDailyPurchaseVsSalesReport> DailyPurchaseVsSalesReport = await Task.FromResult((from pur in PurchaseReport
                                                                                                            join sal in SalesReport
                                                                                                            on pur.ItemId equals sal.ItemId
                                                                                                            select new getItemWiseDailyPurchaseVsSalesReport
                                                                                                            {
                                                                                                                ItemId = pur.ItemId,
                                                                                                                ItemName = pur.ItemName,
                                                                                                                TotalPurPrice = pur.TotalPrice,
                                                                                                                TotalPurQuantity = pur.TotalQuantity,
                                                                                                                TotalSalQuantity = sal.TotalSalQuantity,
                                                                                                                TotalSalPrice = sal.TotalSalPrice
                                                                                                            }
                                                                                                            ).ToList());

            return DailyPurchaseVsSalesReport;



            //try
            //{
            //    List<getItemWiseDailyPurchaseVsSalesReport> DailyPurchaseVsSalesReport = await Task.FromResult((from pur in _context.TblPurchases
            //                                                                                                    join purDel in _context.TblPurchaseDetails
            //                                                                                                    on pur.IntPurchaseId equals purDel.IntPurchaseId
            //                                                                                                    join itm in _context.TblItems
            //                                                                                                    on purDel.IntItemId equals itm.IntItemId
            //                                                                                                    join salD in _context.TblSalesDetails on
            //                                                                                                    itm.IntItemId equals salD.IntItemId
            //                                                                                                    join sal in _context.TblSales
            //                                                                                                    on salD.IntSalesId equals sal.IntSalesId
            //                                                                                                    where ((pur.DtePurchaseDate.Value.Date == DailyPurchaseVsSalesReportDate.Date)
            //                                                                                                    || (sal.DteSalesDate.Value.Date == DailyPurchaseVsSalesReportDate.Date))

            //                                                                                                    group new { purDel, salD } by new { purDel.IntItemId, itm.StrItemName } into g
            //                                                                                                    select new getItemWiseDailyPurchaseVsSalesReport
            //                                                                                                    {
            //                                                                                                        ItemId = g.Key.IntItemId,
            //                                                                                                        ItemName = g.Key.StrItemName,
            //                                                                                                        TotalPurQuantity = g.Sum(s => s.purDel.NumItemQuantity),
            //                                                                                                        TotalPurPrice = g.Sum(s => s.purDel.NumItemQuantity * s.purDel.NumUnitPrice),
            //                                                                                                        TotalSalQuantity = g.Sum(salSum => salSum.salD.NumItemQuantity),
            //                                                                                                        TotalSalPrice = g.Sum(SalP => SalP.salD.NumUnitPrice * SalP.salD.NumItemQuantity)

            //                                                                                                    }
            //                                                                                                    ).ToList());
            //    return DailyPurchaseVsSalesReport;
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        public async Task<List<getItemReportWithGivenColumnReport>> getItemReportWithGivenColumnReport()
        {
            var Purshases = await Task.FromResult((from pur in _context.TblPurchases
                                                   join purDel in _context.TblPurchaseDetails on pur.IntPurchaseId equals purDel.IntPurchaseId
                                                   join itm in _context.TblItems on purDel.IntItemId equals itm.IntItemId
                                                   group new { pur, purDel } by new { pur.DtePurchaseDate.Value.Month, pur.DtePurchaseDate.Value.Year } into g
                                                   select new purchaseModelView
                                                   {

                                                       Month = g.Key.Month,
                                                       Year = g.Key.Year,
                                                       TotalPurPrice = g.Sum(s => s.purDel.NumUnitPrice * s.purDel.NumItemQuantity),

                                                   }).ToList());

            var Sales = await Task.FromResult((from sal in _context.TblSales
                                               join salDel in _context.TblSalesDetails on sal.IntSalesId equals salDel.IntSalesId
                                               join itm in _context.TblItems on salDel.IntItemId equals itm.IntItemId
                                               group new { sal, salDel } by new { sal.DteSalesDate.Value.Year, sal.DteSalesDate.Value.Month } into g
                                               select new SalesModelViewdel
                                               {
                                                   Month = g.Key.Month,
                                                   year = g.Key.Year,
                                                   TotalSalPrice = g.Sum(s => s.salDel.NumItemQuantity * s.salDel.NumUnitPrice)
                                               }).ToList());
            var getItemReportWithGivenColumns = await Task.FromResult((from purs in Purshases
                                                                       join sal in Sales on purs.Year equals sal.year 
                                                                       where purs.Month == sal.Month
                                                                       select new getItemReportWithGivenColumnReport
                                                                       {
                                                                           Month = purs.Month,
                                                                           Year = purs.Year,
                                                                           TotalPurPrice = purs.TotalPurPrice,
                                                                           TotalSalPrice = sal.TotalSalPrice,
                                                                           status = purs.TotalPurPrice > sal.TotalSalPrice ? "Lost" : "Profit"
                                                                       }).ToList()); ;
            return getItemReportWithGivenColumns;
        }
    }
}


//try
//{
//    var data = new Models.TblSale()
//    {

//        IntCustomerId = create.header.CustomerId,
//        DteSalesDate = DateTime.Now,
//        IsActive = true

//    };
//    await _context.TblSales.AddAsync(data);
//    await _context.SaveChangesAsync();
//    List<TblSalesDetail> tblSalesDetailslIST = new List<TblSalesDetail>();
//    foreach (var item in create.details)
//    {
//        var quantity = (from i in _context.TblItems
//                        where i.IntItemId == item.ItemId && i.IsActive == true
//                        select i.NumStockQuantity).FirstOrDefault();
//        var data1 = new Models.TblSalesDetail()
//        {
//            IntSalesId = data.IntSalesId,
//            IntItemId = item.ItemId,
//            NumUnitPrice = item.UnitPrice,
//            NumItemQuantity = item.ItemQuantity,
//            IsActive = true

//        };
//        if (item.ItemQuantity >= quantity)
//        {
//            tblSalesDetailslIST.Add(data1);
//            var row = _context.TblItems.Where(x => x.IntItemId == item.ItemId).FirstOrDefault();
//            row.NumStockQuantity -= item.ItemQuantity;
//            _context.TblItems.Update(row);
//            await _context.SaveChangesAsync();
//        }
//        tblSalesDetailslIST.Add(data1);
//    }
//    await _context.TblSalesDetails.AddRangeAsync(tblSalesDetailslIST);
//    //await _context.SaveChangesAsync();
//    return new MessageHelper()
//    {
//        Message = "Create Successfully",
//        statuscode = 200,
//    };
//}
//catch (Exception)
//{

//    throw;
//}