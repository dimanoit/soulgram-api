using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;
using Soulgram.UserInfo.Models;

namespace Soulgram.UserInfo
{
    public class UserService : IUserInfoService
    {
        private readonly IDriver _driver;

        public UserService(IDriver driver)
        {
            _driver = driver;
        }

        public Task AddAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
