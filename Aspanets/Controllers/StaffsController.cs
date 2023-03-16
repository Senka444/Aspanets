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
using Aspanets.Enities;
using Aspanets.Models.Json;

namespace Aspanets.Controllers
{
    public class StaffsController : ApiController
    {
        private BaseModel db = new BaseModel();

        // GET: api/Staffs
        public IQueryable<Staff> GetStaff()
        {
            return db.Staff;
        }

        // GET: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public IHttpActionResult GetStaff(int id)
        {
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            return Ok(staff);
        }

        // PUT: api/Staffs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStaff(int id, Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != staff.Id)
            {
                return BadRequest();
            }

            db.Entry(staff).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Staffs
        [ResponseType(typeof(Staff))]
        public IHttpActionResult PostStaff(Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Staff.Add(staff);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = staff.Id }, staff);
        }


        // POST: api/Staffs
        [ResponseType(typeof(Staff))]
        public IHttpActionResult AuthStaff(GetCode code)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var staff = db.Staff.Where(s => s.Code == code.Code).FirstOrDefault();
            if (staff != null)
            {
                return Ok(new GetStaffResonse() { Code = staff.Code, Name = staff.Name });
            }
            else 
            {
                return NotFound();
            }   
        }

        // DELETE: api/Staffs/5
        [ResponseType(typeof(Staff))]
        public IHttpActionResult DeleteStaff(int id)
        {
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return NotFound();
            }

            db.Staff.Remove(staff);
            db.SaveChanges();

            return Ok(staff);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StaffExists(int id)
        {
            return db.Staff.Count(e => e.Id == id) > 0;
        }
    }
}