using Microsoft.EntityFrameworkCore;

namespace Ecommerce.RepositoryLayer.Interfaces;

public interface IUnitOfWork : IDisposable
{
    //-----------------------------------------------------------------------------------
    int SaveChanges();

    Task<int> SaveChangesAsync();
}