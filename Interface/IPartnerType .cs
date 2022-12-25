using PurcheseWork.DTO;
using PurcheseWork.Helper;

namespace PurcheseWork.Interface
{
    public interface IPartnerType
    {
        public Task<MessageHelper> Create(PartnerTypeDTO create);
    }
}
