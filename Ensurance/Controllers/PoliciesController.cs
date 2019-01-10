using Ensurance.Data;
using Ensurance.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace Ensurance.Controllers
{
    public class PoliciesController : ApiController
    {
        private readonly IRepository repository;

        public PoliciesController()
        {
            this.repository = new Repository();
        }

        // GET api/<controller>
        [ResponseType(typeof(List<PolicyDTO>))]
        public IHttpActionResult Get()
        {
            List<PolicyDTO> policies = repository.GetPolicies();
            return Ok(policies);
        }

        // GET api/<controller>/5
        [ResponseType(typeof(PolicyDTO))]
        public IHttpActionResult Get(int id)
        {
            PolicyDTO policy = repository.GetPolicy(id);
            return Ok(policy);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]PolicyDTO policy)
        {
            try
            {
                repository.UpdatePolicy(policy);
                return Ok();
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}