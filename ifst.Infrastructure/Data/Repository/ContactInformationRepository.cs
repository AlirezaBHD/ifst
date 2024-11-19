using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Infrastructure.Data.Repository;

public class ContactInformationRepository:Repository<ContactInformation>, IContactInformationRepository
{
    private readonly ApplicationDbContext _context;

    public ContactInformationRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}