using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Table;
using LinqKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ApiTest.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QueryPageController : Controller
    {
        UnitOfWork _unitOfWork;
        public QueryPageController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 分页测试
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get(string userName,int? Status,string NikeName)
        {
            var userCount = _unitOfWork.SysUserRepository.Count();
            if(userCount < 100)
            {
                await CreateUser(100);
            }
            //获取分页数据方式1
            //获取用户名包含user的排序根据Sort正序，CreateTime倒序排序的第1页的20条数据
            var pageModel = await _unitOfWork.SysUserRepository.GetPageAsync(o => o.UserName.Contains("user") && o.Status == 1, "Sort,-CreateTime", 1, 20);

            //获取分页数据方式2
            //使用PredicateBuilder获取分页数据方式支持筛选
            var predicate = PredicateBuilder.New<SysUser>(true);//查询条件,推荐后台使用这种方式灵活筛选
            #region 添加条件查询
            if (!string.IsNullOrEmpty(userName))
            {
                predicate = predicate.And(i => i.UserName.Contains(userName));
            }
            if (Status != null)
            {
                predicate = predicate.And(i => i.Status.Equals(Status));
            }
            if (!string.IsNullOrEmpty(NikeName))
            {
                predicate = predicate.And(i => i.NikeName.Equals(NikeName));
            }
            #endregion
            var pageModel1 = await _unitOfWork.SysUserRepository.GetPageAsync(predicate, "Sort,-CreateTime", 1, 20);
            return Json(new { pageModel, pageModel1 });
        }
        /// <summary>
        /// 构造数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<bool> CreateUser(int count = 1)
        {
            List<SysUser> inserUsers = new List<SysUser>();
            for (int i = 0; i < count; i++)
            {
                inserUsers.Add(new SysUser
                {
                    SysUserId = Guid.NewGuid().ToString("N"),
                    UserName = $"user{i}",
                    Password = "123456",
                    UserType = "0",
                    CreateTime = DateTime.Now,
                    Status = 1,
                    Sort = 0
                });
            }
            return await _unitOfWork.SysUserRepository.InsertAsync(inserUsers);
        }
        /// <summary>
        /// 更新数据，部分字段更新
        /// </summary>
        /// <param name="sysUser"></param>
        /// <returns></returns>
        public bool Update(SysUser sysUser)
        {
            //只更新实体的CreateTime和Mobile字段
            return _unitOfWork.SysUserRepository.Update(sysUser,true,new List<string> { nameof(SysUser.CreateTime), nameof(SysUser.Mobile), });
        }
    }
}