using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using armaguidonAPI.Models;

namespace armaguidonAPI.Controllers
{
    public class DashboardsController : ApiController
    {
        private armaguidonAPIContext db = new armaguidonAPIContext();

        // GET: api/Dashboards
        public IQueryable<Dashboard> GetDashboards()
        {
            return db.Dashboards.Include(d => d.User);
        }

        // GET: api/Dashboards/5
        [ResponseType(typeof(Dashboard))]
        public async Task<IHttpActionResult> GetDashboard(int id)
        {
            Dashboard dashboard = await db.Dashboards.Include(d => d.User).SingleOrDefaultAsync(d => d.DashboardId == id);
            if (dashboard == null)
            {
                return NotFound();
            }

            return Ok(dashboard);
        }

        // PUT: api/Dashboards/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDashboard(int id, Dashboard dashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dashboard.DashboardId)
            {
                return BadRequest();
            }

            db.Entry(dashboard).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DashboardExists(id))
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

        // POST: api/Dashboards
        [ResponseType(typeof(Dashboard))]
        public async Task<IHttpActionResult> PostDashboard(Dashboard dashboard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Dashboards.Add(dashboard);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = dashboard.DashboardId }, dashboard);
        }

        // DELETE: api/Dashboards/5
        [ResponseType(typeof(Dashboard))]
        public async Task<IHttpActionResult> DeleteDashboard(int id)
        {
            Dashboard dashboard = await db.Dashboards.Include(d => d.User).SingleOrDefaultAsync(d => d.DashboardId == id);
            if (dashboard == null)
            {
                return NotFound();
            }

            db.Dashboards.Remove(dashboard);
            await db.SaveChangesAsync();

            return Ok(dashboard);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DashboardExists(int id)
        {
            return db.Dashboards.Count(e => e.DashboardId == id) > 0;
        }
    }
}