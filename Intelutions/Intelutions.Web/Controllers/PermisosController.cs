using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Intelutions.Data;
using Intelutions.Entities.Confidencialidad;
using Intelutions.Web.Models.Confidencialidad;

namespace Intelutions.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisosController : ControllerBase
    {
        private readonly DbContextIntelutions _context;

        public PermisosController(DbContextIntelutions context)
        {
            _context = context;
        }

        // GET: api/Permisos/List
        [HttpGet("[action]")]
        public async Task<IEnumerable<PermisoViewModel>> List()
        {
            var permiso = await _context.Permisos.ToListAsync();

            return permiso.Select(p => new PermisoViewModel { 
                Id = p.Id,
                NombreEmpleado = p.NombreEmpleado,
                ApellidosEmpleado = p.ApellidosEmpleado,
                TipoPermiso = p.TipoPermiso,
                FechaPermiso = p.FechaPermiso
            });
        }

        // GET: api/Permisos/Show/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Permiso>> Show(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);

            if (permiso == null)
            {
                return NotFound();
            }

            return Ok(new PermisoViewModel {
                Id = permiso.Id,
                NombreEmpleado = permiso.NombreEmpleado,
                ApellidosEmpleado = permiso.ApellidosEmpleado,
                TipoPermiso = permiso.TipoPermiso,
                FechaPermiso = permiso.FechaPermiso
            });
        }

        // PUT: api/Permisos/Update
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(UpdatePermisoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Id < 0)
            {
                return BadRequest();
            }

            var permiso = await _context.Permisos.FirstOrDefaultAsync(p => p.Id == model.Id);

            if (permiso == null)
            {
                return NotFound();
            }

            permiso.NombreEmpleado = model.NombreEmpleado;
            permiso.ApellidosEmpleado = model.ApellidosEmpleado;
            permiso.TipoPermiso = model.TipoPermiso;
            permiso.FechaPermiso = (DateTime)model.FechaPermiso;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Permisos/Create
        [HttpPost("[action]")]
        public async Task<ActionResult<Permiso>> Create(CreatePermisoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Permiso permiso = new Permiso {
                NombreEmpleado = model.NombreEmpleado,
                ApellidosEmpleado = model.ApellidosEmpleado,
                TipoPermiso = model.TipoPermiso,
                FechaPermiso = (DateTime)model.FechaPermiso
            };

            _context.Permisos.Add(permiso);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Permisos/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult<Permiso>> Delete(int id)
        {
            var permiso = await _context.Permisos.FindAsync(id);
            if (permiso == null)
            {
                return NotFound();
            }

            _context.Permisos.Remove(permiso);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok(permiso);
        }
    }
}
