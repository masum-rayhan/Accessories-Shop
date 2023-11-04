
using Accessories.DataAccess.Data;
using Accessories.DataAccess.Repository.IRepository;
using Accessories.DataAccess.Repository.IRepository.Services;
using Accessories.DataAccess.Repository.Services;

namespace Accessories.DataAccess.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _db;
    private readonly BlobService _blobService;

    public UnitOfWork(ApplicationDbContext db, BlobService blobService)
    {
        _db = db;
        _blobService = blobService;
    }

    public IMenuItemRepo MenuItems => new MenuItemRepo(_db, _blobService);

    public IBlobService BlobService => _blobService;

    public async Task SaveAsync()
    {
        await _db.SaveChangesAsync();
    }
}
