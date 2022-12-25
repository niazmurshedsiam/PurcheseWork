using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PurcheseWork.DTO
{
    public class PartnerTypeDTO
    {
        
        public string? StrPartnerTypeName { get; set; }
        public bool? IsActive { get; set; }
    }
}
