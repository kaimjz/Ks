using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ks.Models;
using Ks.Repository.Repository;

namespace Ks.Domain
{
    public class AuthoriseService
    {
        protected UserRepository userRepository;
        public AuthoriseService()
        {
            userRepository = new UserRepository();
        }
        public Guid User { get; set; }

        public Users Find(string account)
        {
            return userRepository.FindSingle(u => u.Account == account);
        }
    }
}
