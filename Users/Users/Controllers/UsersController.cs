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

        public HttpResponseMessage Post([FromBody]usersTable users) {

            try
            {
                using (shehryarTestingDBEntities entities = new shehryarTestingDBEntities())
                {
                    entities.usersTables.Add(users);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, users);
                    message.Headers.Location = new Uri(Request.RequestUri + users.userID.ToString());
                    return message;
                }
            }
            catch (Exception ex) {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
