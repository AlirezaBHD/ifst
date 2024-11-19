using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository
{
    public class ContactUsRepository :Repository<ContactUs>, IContactUsRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactUsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}