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
    public class RisksController : ApiController
    {
        private readonly IRepository repository;

        public RisksController()
        {
            this.repository = new Repository();
        }


        // GET: api/Risks
        [ResponseType(typeof(List<RiskDTO>))]
        public IHttpActionResult Get()
        {
            List<RiskDTO> risks = this.repository.GetRisks();
            return Ok(risks);
        }

        // GET: api/Risks/5
        [ResponseType(typeof(RiskDTO))]
        public IHttpActionResult Get(int id)
        {
            RiskDTO risk = this.repository.GetRisk(id);
            return Ok(risk);
        }

        // POST: api/Risks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Risks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Risks/5
        public void Delete(int id)
        {
        }
    }
}
