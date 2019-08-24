using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Core.Repositories;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.IRepositories;

namespace API.Controllers
{
    public class PrioritiesController : ApiController
    {
        private readonly IPriorityRepository _repository;

        public PrioritiesController()
        {
            _repository = new PriorityRepository(); 
        }

        public PrioritiesController(IPriorityRepository repo)
        {
            _repository = repo;
        }

        // GET: api/Priorities
        public List<Priority> GetPriorities()
        {
            return _repository.GetAll();
        }

        // PUT: api/Priorities
        [ResponseType(typeof(Priority))]
        public IHttpActionResult PutPriority(Priority priority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(priority);
            _repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = priority.Id }, priority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}