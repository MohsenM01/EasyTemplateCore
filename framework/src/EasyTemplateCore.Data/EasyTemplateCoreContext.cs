using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EasyTemplateCore.Entities;
using EasyTemplateCore.Entities.Location;
using System.Reflection;
using System;
using System.Linq;

namespace EasyTemplateCore.Data
{
    public class EasyTemplateCoreContext : DbContext, IUnitOfWork
    {

        public EasyTemplateCoreContext(DbContextOptions<EasyTemplateCoreContext> options) : base(options) { }

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyEntitiesConfigurations(modelBuilder);
			
			modelBuilder.Entity<Country>()
                .HasIndex(b => b.CountryNo)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(b => b.CountryName)
                .IsUnique();

            modelBuilder.Entity<Country>()
                .HasIndex(b => b.CountryAbbr)
                .IsUnique();
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        #endregion

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            Set<TEntity>().AddRange(entities);
        }

        public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : BaseEntity
        {
            Set<TEntity>().RemoveRange(entities);
        }

        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            Entry(entity).State = EntityState.Modified; // Or use ---> this.Update(entity);
        }

        public int SaveAllChanges()
        {
            return SaveChanges();
        }

        public Task<int> SaveAllChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            ChangeTracker.DetectChanges();
            //var changedEntityNames = this.GetChangedEntityNames();

            ChangeTracker.AutoDetectChangesEnabled = false; // for performance reasons, to avoid calling DetectChanges() again.
            var result = SaveChangesAsync(cancellationToken);
            ChangeTracker.AutoDetectChangesEnabled = true;

            // this.GetService<IEFCacheServiceProvider>().InvalidateCacheDependencies(changedEntityNames);

            return result;
        }

        public static void ApplyEntitiesConfigurations(ModelBuilder modelBuilder)
        {
            var entityConfigurations = Assembly.GetAssembly(typeof(BaseEntity)).GetTypes()
                .Where(w => w.GetInterfaces()
                    .Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)))
                .ToList();

            foreach (var config in entityConfigurations)
            {
                dynamic configurationInstance = Activator.CreateInstance(config);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

        }
    }
}