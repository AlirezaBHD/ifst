using AutoMapper;
using ifst.API.ifst.Application.Exceptions;
using ifst.API.ifst.Application.Interfaces;
using ifst.API.ifst.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ifst.API.ifst.Infrastructure.Data.Repository
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AlbumRepository(ApplicationDbContext context,IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void RemoveImagesOfAlbum(int id)
        {
            _context.Albums.Include(album => album.Images).FirstOrDefaultAsync(album => album.Id == id);
        }

        public async Task<Album> GetAlbumByIdAsync(int id)
        {
            
            var album = await _context.Albums
                .Include(a => a.Images).FirstOrDefaultAsync(a => a.Id == id);
            
            // if (album == null){throw new NotFoundException("Item not found.!!");}
            album.ThrowIfNull("آلبوم");

            return album;
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
            // throw new NotImplementedException();
        }
    }
}