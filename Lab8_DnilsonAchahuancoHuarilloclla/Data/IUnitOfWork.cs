using Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Data;

public interface IUnitOfWork : IDisposable
{
    // Acceso a todos los repositorios
    IClientRepository Clients { get; }
    IProductRepository Products { get; }
    IOrderRepository Orders { get; }
    IOrderDetailRepository OrderDetails { get; }
    
    // Gestión de cambios
    Task<int> SaveChangesAsync();
    
    // Gestión de transacciones
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}