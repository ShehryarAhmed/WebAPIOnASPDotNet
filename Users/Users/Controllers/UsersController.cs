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

        public HttpResponseMessage Get(int id)
        {
            using (shehryarTestingDBEntities entities = new shehryarTestingDBEntities())
            {
                var entity = entities.usersTables.FirstOrDefault(e => e.userID == id);

                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Employee with id " + id.ToString() + " not found");
                }

            }
        }

        public HttpResponseMessage Post([FromBody]usersTable users)
        {

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
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage PUT([FromBody]usersTable users)
        {

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
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }
        public void Delete(int id)
        {
            using (shehryarTestingDBEntities entities = new shehryarTestingDBEntities())
            {
                entities.usersTables.Remove(entities.usersTables.FirstOrDefault(e => e.userID == id));
                entities.SaveChanges();
            }

        }
    }
}
