using Ensurance.Auth;
using Ensurance.Data;
using Ensurance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Ensurance.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IRepository repository;

        public LoginController()
        {
            this.repository = new Repository();
        }

        // PUT: api/Login/5
        public async Task<IHttpActionResult> PostAsync([FromBody]Authentication login)
        {
            IHttpActionResult response = null;
            AuthenticatedUser authUser;
            try
            {
                authUser = repository.AuthenticateUser(login);
                if (authUser == null)
                {
                    response = Content(HttpStatusCode.NotFound, "User not found"); ;
                }
                else
                {
                    var token = await TokenGenerator.Generate();
                    authUser.Token = token;
                    TokenStorage.GetInstance().SaveToken(authUser.Token);
                    response = Ok(authUser);
                }
            }
            catch (Exception ex)
            {
                // Write the excption to a log
                response = InternalServerError();
            }

            return response;
        }
        
        public IHttpActionResult PutAsync([FromBody] Model.AuthenticatedUser login)
        {
            try
            {
                TokenStorage.GetInstance().RemoveToken(login.Token);
                AuthenticatedUser authUser = new AuthenticatedUser();
                return Ok(authUser);
            }
            catch (Exception ex)
            {
                // Write the excption to a log
                return InternalServerError();
            }
        }

        // DELETE: api/Login/5
        public void Delete(int id)
        {
        }
    }
}
