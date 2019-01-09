using Entity;
using Entity.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Table
{
    public class SysUserRepository : RepositoryBase<SysUser>
    {
        public SysUserRepository(AeDbContext context) : base(context)
        {
        }
    }
}
