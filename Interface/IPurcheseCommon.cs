﻿using PurcheseWork.DTO;
using PurcheseWork.Helper;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.Interface
{
    public interface IPurcheseCommon
    {
        public  Task<MessageHelper> CreatePartnerType(PartnerTypeViewModel create);
        public Task<MessageHelper> CreatePartner(PartnerViewModel create);

        public Task<MessageHelper> CreateItems(List<ItemsViewModel> createlist);
    }
}
