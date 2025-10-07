using Lab8_DnilsonAchahuancoHuarilloclla.Repositories;
using Lab8_DnilsonAchahuancoHuarilloclla.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Lab8_DnilsonAchahuancoHuarilloclla.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly LinqExampleContext _context;
    private IDbContextTransaction? _transaction;

    public IClientRepository Clients { get; }
    public IProductRepository Products { get; }
    public IOrderRepository Orders { get; }
    public IOrderDetailRepository OrderDetails { get; }

    public UnitOfWork(LinqExampleContext context)
    {
        _context = context;
        
        // Inicializar todos los repositorios con el mismo contexto
        Clients = new ClientRepository(_context);
        Products = new ProductRepository(_context);
        Orders = new OrderRepository(_context);
        OrderDetails = new OrderDetailRepository(_context);
    }

    /// <summary>
    /// Guarda todos los cambios pendientes en la base de datos
    /// </summary>
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Inicia una nueva transacción
    /// </summary>
    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    /// <summary>
    /// Confirma la transacción actual y guarda los cambios
    /// </summary>
    public async Task CommitTransactionAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
            }
        }
        catch
        {
            await RollbackTransactionAsync();
            throw;
        }
        finally
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }

    /// <summary>
    /// Revierte la transacción actual
    /// </summary>
    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    /// <summary>
    /// Libera los recursos utilizados
    /// </summary>
    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}