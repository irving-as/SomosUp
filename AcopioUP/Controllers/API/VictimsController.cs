using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AcopioUP.Dtos;
using AcopioUP.Models;
using AutoMapper;

namespace AcopioUP.Controllers.API
{
    public class VictimsController : ApiController
    {

        private readonly ApplicationDbContext _context;

        public VictimsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/victims
        public IHttpActionResult GetVictims()
        {
            return Ok(_context.Victims.ToList().Select(Mapper.Map<Victim, VictimDto>));
        }

        // GET /api/victims/{id}
        public IHttpActionResult GetVictim(int id)
        {
            var victim = _context.Victims.SingleOrDefault(v => v.Id == id);
            if (victim == null)
                return NotFound();

            return Ok(Mapper.Map<Victim, VictimDto>(victim));
        }

        // POST api/victims
        [HttpPost]
        public IHttpActionResult CreateVictim(VictimDto victimDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var victim = Mapper.Map<VictimDto, Victim>(victimDto);

            _context.Victims.Add(victim);
            _context.SaveChanges();
            victimDto.Id = victim.Id;
            return Created(new Uri($"{Request.RequestUri}/{victimDto.Id}"), victimDto);
        }

        //PUT api/victims/{id}
        [HttpPut]
        public IHttpActionResult UpdateVictim(int id, VictimDto victimDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victimInDb == null)
                return NotFound();

            //victimDto.Id = id; //I know... but If "Id" in victimDto is changed (i.e. not sent), an exception is thrown
            Mapper.Map(victimDto, victimInDb); 

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/victim/{id}
        [HttpDelete]
        public IHttpActionResult DeleteVictim(int id)
        {
            var victimInDb = _context.Victims.SingleOrDefault(v => v.Id == id);

            if (victimInDb == null)
                return NotFound();

            _context.Victims.Remove(victimInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
