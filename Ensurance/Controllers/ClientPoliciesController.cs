using Ensurance.Auth;
using Ensurance.Data;
using Ensurance.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Ensurance.Controllers
{
    public class ClientPoliciesController : ApiController
    {
        private readonly IRepository repository;

        public ClientPoliciesController()
        {
            this.repository = new Repository();
        }

        // GET: api/ClientPolity
        public void Get()
        {

        }

        // GET: api/ClientPolicies/client/5
        [HttpGet, Route("api/clientpolicies/clients/{clientid}")]
        public IHttpActionResult Get(int clientId)
        {
            try
            {
                List<ClientPolicyDTO> clientPolicy = repository.GetClientPolicyByClientId(clientId);
                return Ok(clientPolicy);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // POST: api/ClientPolity
        [CustomAuthorize]
        public async Task<IHttpActionResult> Post([FromBody]ClientPolicyDTO newClientPolicy)
        {
            try
            {
                ClientPolicyDTO resultPolicy = await repository.AddClientPolicy(newClientPolicy);
                return Content(HttpStatusCode.Created, resultPolicy);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/ClientPolity/5
        [CustomAuthorize]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                await repository.DeleteClientPolicy(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
