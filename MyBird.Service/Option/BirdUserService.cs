using MyBird.Model.Option;
using MyBird.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Service.Option
{
    public class BirdUserService:ServiceBase<BirdUser>
    {
        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.UserName == userName && x.Password == password);
        }

        public BirdUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);
        }

        public BirdUser FindByEmail(string email)
        {
            return GetByDefault(x => x.Email == email);
        }
    }
}
