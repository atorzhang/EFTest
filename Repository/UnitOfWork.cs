using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IDisposable
    {
        public static UnitOfWork Instance = new UnitOfWork(new AeDbContext());
        public AeDbContext DbContext { get; set; } = null;
        public UnitOfWork(AeDbContext dbContext)
        {
            DbContext = dbContext;
        }

        #region 字段
        private SysUserRepository _SysUserRepository = null;
        #endregion

        #region 操作类属性
        public SysUserRepository SysUserRepository => _SysUserRepository ?? (_SysUserRepository = new SysUserRepository(DbContext));
        #endregion

        #region 仓储操作（提交事务保存SaveChanges(),回滚RollBackChanges(),释放资源Dispose()）
        /// <summary>
        /// 保存
        /// </summary>
        public int SaveChanges()
        {
            return DbContext.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await DbContext.SaveChangesAsync();
        }
        /// <summary>
        /// 回滚
        /// </summary>
        public void RollBackChanges()
        {
            var items = DbContext.ChangeTracker.Entries().ToList();
            items.ForEach(o => o.State = EntityState.Unchanged);
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    DbContext.Dispose();//随着工作单元的销毁而销毁
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public IDbContextTransaction BeginTransaction()
        {
            var scope = DbContext.Database.BeginTransaction();
            return scope;
        }
        #endregion
    }
}