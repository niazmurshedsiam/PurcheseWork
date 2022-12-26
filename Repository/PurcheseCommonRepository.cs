using PurcheseWork.DbContexts;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;
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
    }
}
