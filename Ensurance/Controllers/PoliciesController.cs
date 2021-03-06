﻿using Ensurance.Auth;
using Ensurance.Data;
using Ensurance.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

        // GET api/policies
        [ResponseType(typeof(List<PolicyBasicInfoDTO>))]
        [HttpGet, Route("api/policies/basicinfo")]
        public IHttpActionResult GetBasicInfo()
        {
            List<PolicyBasicInfoDTO> policiesBasicInfo = repository.GetPoliciesBasicInfo();
            return Ok(policiesBasicInfo);
        }

        // GET api/policies
        [ResponseType(typeof(List<PolicyDTO>))]
        public IHttpActionResult Get()
        {
            List<PolicyDTO> policies = repository.GetPolicies();
            return Ok(policies);
        }

        // GET api/policies/5
        [ResponseType(typeof(PolicyDTO))]
        public IHttpActionResult Get(int id)
        {
            PolicyDTO policy = repository.GetPolicy(id);
            return Ok(policy);
        }

        // GET api/policiesallinfo/5
        [ResponseType(typeof(PolicyCompleteDTO))]
        [HttpGet, Route("api/policiesallinfo/{id}")]
        public IHttpActionResult GetFull(int id)
        {
            PolicyCompleteDTO policy = repository.GetPolicyComplete(id);
            return Ok(policy);
        }

        // POST api/policies
        [CustomAuthorize]
        [ResponseType(typeof(PolicyDTO))]
        public async Task<IHttpActionResult> PostAsync([FromBody]PolicyDTO policy)
        {
            if (policy == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                PolicyDTO updatedPolicy = await repository.AddPolicy(policy);
                return Content(HttpStatusCode.Created, updatedPolicy);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/policies/5
        [CustomAuthorize]
        [ResponseType(typeof(PolicyDTO))]
        public async Task<IHttpActionResult> PutAsync(int id, [FromBody]PolicyDTO policy)
        {
            if (policy == null || !ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                policy.Id = id;
                PolicyDTO updatedPolicy = await repository.UpdatePolicy(policy);
                return Ok(updatedPolicy);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/policies/5
        [CustomAuthorize]
        public async Task<IHttpActionResult> DeleteAsync(int id)
        {
            try
            {
                await repository.DeletePolicy(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}