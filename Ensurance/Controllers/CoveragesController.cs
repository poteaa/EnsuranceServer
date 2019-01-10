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
    public class CoveragesController : ApiController
    {
        private readonly IRepository repository;

        public CoveragesController()
        {
            this.repository = new Repository();
        }

        // GET: api/Coverages
        [ResponseType(typeof(List<CoverageDTO>))]
        public IHttpActionResult Get()
        {
            List<CoverageDTO> coverages = this.repository.GetCoverages();
            return Ok(coverages);
        }

        // GET: api/Coverages/5
        [ResponseType(typeof(CoverageDTO))]
        public IHttpActionResult Get(int id)
        {
            CoverageDTO coverage = this.repository.GetCoverage(id);
            return Ok(coverage);
        }

        // POST: api/Coverages
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Coverages/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Coverages/5
        public void Delete(int id)
        {
        }
    }
}
