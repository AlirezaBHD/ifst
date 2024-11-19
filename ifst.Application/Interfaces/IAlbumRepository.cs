using System.Linq.Expressions;
using ifst.API.ifst.Domain.Entities;

namespace ifst.API.ifst.Application.Interfaces
{
    public interface IAlbumRepository :IRepository<Album>
    {
        void RemoveImagesOfAlbum(int id);
        
        Task<Album> GetAlbumByIdAsync(int id);

    }
}