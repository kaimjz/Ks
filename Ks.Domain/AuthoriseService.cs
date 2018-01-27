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

        public Users GetUser(string account)
        {
            return new UserRepository().FindSingle(u => u.Account == account);
        }

        public virtual IQueryable<Modules> GetModules()
        {
            var moduleIds = new RelevancesRepository().Find(f => f.FirstId == User.Id).Select(f => f.SecondId);
            return new ModulesRepository().Find(f => moduleIds.Contains(f.Id)).OrderBy(f => f.Sort);
        }
    }
}
