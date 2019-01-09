using Entity.Table;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Entity
{
    public class AeDbContext : DbContext
    {
        #region 构造方法
        public AeDbContext(DbContextOptions<AeDbContext> options) : base(options) { }

        public AeDbContext() { } //非注入构造方式
        #endregion

        #region 表对象
        public virtual DbSet<SysUser> SysUsers { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                //重点:数据迁移或者直接New AeDbContext时候用到的链接字符串获取方式
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();
                string connectionString = configuration.GetConnectionString("SQLConnection");
                optionsBuilder.UseMySql(connectionString);
            }

        }

    }
}
