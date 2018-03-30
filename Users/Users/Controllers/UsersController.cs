using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UserDataAccess;

namespace Users.Controllers
{
    public class UsersController : ApiController
    {
        public IEnumerable<usersTable> Get()
        {
            using (shehryarTestingDBEntities entities = new shehryarTestingDBEntities())
            {
                return entities.usersTables.ToList();
            }
        }

        public usersTable Get(int id)
        {
            using (shehryarTestingDBEntities entities = new shehryarTestingDBEntities())
            {
                return entities.usersTables.FirstOrDefault(e => e.userID == id);
            }
        }
    }
}
