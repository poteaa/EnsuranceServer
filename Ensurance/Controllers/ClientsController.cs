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
    public class ClientsController : ApiController
    {
        private readonly IRepository repository;

        public ClientsController()
        {
            this.repository = new Repository();
        }

        // GET: api/clients/basicinfo
        [ResponseType(typeof(List<ClientBasicInfoDTO>))]
        [HttpGet, Route("api/clients/basicinfo")]
        public IHttpActionResult GetBasicInfo()
        {
            List<ClientBasicInfoDTO> clientsBasicInfo = repository.GetClientsBasicInfo();
            return Ok(clientsBasicInfo);
        }

        // GET: api/clients/basicinfo
        [ResponseType(typeof(ClientBasicInfoDTO))]
        [HttpGet, Route("api/clients/{id}/basicinfo")]
        public IHttpActionResult GetBasicInfo(int id)
        {
            ClientBasicInfoDTO clientBasicInfo = repository.GetClientBasicInfo(id);
            return Ok(clientBasicInfo);
        }

        //GET: api/Clients/5
        [ResponseType(typeof(ClientDTO))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                ClientDTO client = repository.GetClient(id);
                 return Ok(client);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Clients
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Clients/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clients/5
        public void Delete(int id)
        {
        }
    }
}
