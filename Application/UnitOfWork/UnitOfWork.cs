using Aplicacion.Repository;
using Application.Repository;
using Domain.Interfaces;
using Persistence;
namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiDbContext _context;
    private IRol _rols;
    private IUser _users;
    

    
    public UnitOfWork(ApiDbContext context)
    {
        _context = context;
    }

    public IUser Users
    {
        get
        {
            _users ??= new UserRepository(_context);
            return _users;
        }
    }


   public IRol Rols
    {
        get
        {
            _rols ??= new RolRepository(_context);
            return _rols;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}