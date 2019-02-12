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
using armaguidonAPI.Models;

namespace armaguidonAPI.Controllers
{
    public class DashboardItemsController : ApiController
    {
        private armaguidonAPIContext db = new armaguidonAPIContext();

        // GET: api/DashboardItems
        public IQueryable<DashboardItem> GetDashboardItems()
        {
            return db.DashboardItems;
        }

        // GET: api/DashboardItems/5
        [ResponseType(typeof(DashboardItem))]
        public IHttpActionResult GetDashboardItem(int id)
        {
            DashboardItem dashboardItem = db.DashboardItems.Find(id);
            if (dashboardItem == null)
            {
                return NotFound();
            }

            return Ok(dashboardItem);
        }

        // PUT: api/DashboardItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDashboardItem(int id, DashboardItem dashboardItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dashboardItem.ItemId)
            {
                return BadRequest();
            }

            db.Entry(dashboardItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardItemExists(id))
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

        // POST: api/DashboardItems
        [ResponseType(typeof(DashboardItem))]
        public IHttpActionResult PostDashboardItem(DashboardItem dashboardItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DashboardItems.Add(dashboardItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dashboardItem.ItemId }, dashboardItem);
        }

        // DELETE: api/DashboardItems/5
        [ResponseType(typeof(DashboardItem))]
        public IHttpActionResult DeleteDashboardItem(int id)
        {
            DashboardItem dashboardItem = db.DashboardItems.Find(id);
            if (dashboardItem == null)
            {
                return NotFound();
            }

            db.DashboardItems.Remove(dashboardItem);
            db.SaveChanges();

            return Ok(dashboardItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DashboardItemExists(int id)
        {
            return db.DashboardItems.Count(e => e.ItemId == id) > 0;
        }
    }
}