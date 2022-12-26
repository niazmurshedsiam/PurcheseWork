﻿namespace PurcheseWork.DTO
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
            public long NumStockQuantity { get; set; }
            public bool? IsActive { get; set; }
        }
    }
}