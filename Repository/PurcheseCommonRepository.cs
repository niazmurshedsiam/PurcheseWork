﻿using PurcheseWork.DbContexts;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;
using PurcheseWork.Models;
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
            try
            {
                List<TblItem> newitemList = new List<TblItem>();
                foreach (var item in createlist)
                {
                    var DuplicateValue = _context.TblItems.Where(x => x.StrItemName == item.StrItemName && x.IsActive == true)
                        .Select(a => a).FirstOrDefault();
                    if (DuplicateValue != null)
                    {
                        throw new Exception($"Already Exits");
                    }
                    var data = new Models.TblItem()
                    {
                        StrItemName = item.StrItemName,
                        NumStockQuantity = item.NumStockQuantity,
                        IsActive = true,
                    };
                    newitemList.Add(data);  
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
                    var DuplicateValue = _context.TblItems.Where(x=>x.IntItemId != item.IntItemId &&  x.StrItemName == item.StrItemName && x.IsActive == true)
                        .Select(a => a).FirstOrDefault();
                    if (DuplicateValue != null)
                    {
                        throw new Exception($"Already Exits");
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
    }
}
