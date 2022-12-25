using Microsoft.AspNetCore.Http;
using PurcheseWork.DbContexts;
using PurcheseWork.DTO;
using PurcheseWork.Helper;
using PurcheseWork.Interface;

namespace PurcheseWork.Repository
{
    public class PartnerTypeRepository : IPartnerType
    {
        private readonly AppDbContext _context;
        public PartnerTypeRepository(AppDbContext dbContext) 
        {
            _context = dbContext;
        }
        public async Task<MessageHelper> Create(PartnerTypeDTO create)
        {
            try
            {
                var data = new Models.TblPartnerType()
                {
                    StrPartnerTypeName = create.StrPartnerTypeName,
                    IsActive = create.IsActive,
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
