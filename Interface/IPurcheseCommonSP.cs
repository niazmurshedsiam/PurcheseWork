using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Models;
using static PurcheseWork.DTO.CommonDTO;

namespace PurcheseWork.Interface
{
    public interface IPurcheseCommonSP
    {
        public Task<MessageHelper> CreatePartner(PartnerViewModel create);
    }
}
