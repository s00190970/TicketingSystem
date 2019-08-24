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
using Core.IRepositories;
using Infrastructure.Context;
using Infrastructure.Entities;
using Infrastructure.Repositories;

namespace API.Models
{
    public class PrioritiesController : ApiController
    {
        private readonly IPriorityRepository repository;

        public PrioritiesController()
        {
            repository = new PriorityRepository(); 
        }

        public PrioritiesController(IPriorityRepository repo)
        {
            repository = repo;
        }

        // GET: api/Priorities
        public List<Priority> GetPriorities()
        {
            return repository.GetAll();
        }

        // PUT: api/Priorities
        [ResponseType(typeof(Priority))]
        public IHttpActionResult PutPriority(Priority priority)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repository.Add(priority);
            repository.Save();

            return CreatedAtRoute("DefaultApi", new { id = priority.Id }, priority);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}