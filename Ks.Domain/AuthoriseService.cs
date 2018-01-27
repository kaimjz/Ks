using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ks.Models;
using Ks.Repository.Repository;
using Infrastructure.Cache;

namespace Ks.Domain
{
    public class AuthoriseService
    {
        private UserRepository userRepository = new UserRepository();
        private static CacheProvider<Users> cacheObj = new CacheProvider<Users>();
        public AuthoriseService()
        {
        }
        public static Users User
        {
            get
            {
                return cacheObj.GetCache("user");
            }
            set
            {
                cacheObj.CreateCache("user", value, DateTime.Now.AddHours(12));
            }
        }

        public Users FindUser(string account)
        {
            return userRepository.FindSingle(u => u.Account == account);
        }
    }
}
