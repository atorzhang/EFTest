using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repository;

namespace ApiTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        UnitOfWork _unitOfWork;
        public ValuesController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var adminModel = _unitOfWork.SysUserRepository.Get("admin");
            if(adminModel == null)
            {
                adminModel = new Entity.Table.SysUser()
                {
                    SysUserId = "admin",
                    UserName = "admin",
                    Password = "123456",
                    UserType = "1",
                    CreateTime = DateTime.Now,
                    Status = 1,
                    Sort = 0
                };
                _unitOfWork.SysUserRepository.Insert(adminModel);
            }
            return new List<string> { adminModel.UserName , adminModel.Password };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
