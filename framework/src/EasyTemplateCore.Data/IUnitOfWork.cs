using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EasyTemplateCore.Entities;

namespace EasyTemplateCore.Data
{
    public interface IUnitOfWork : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;
        void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity;

        void MarkAsChanged<TEntity>(TEntity entity) where TEntity : BaseEntity;

        int SaveChanges(bool acceptAllChangesOnSuccess);

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

        DatabaseFacade Database { get; }
    }
}
