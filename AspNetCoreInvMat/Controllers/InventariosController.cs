using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreInvMat.Data;
using AspNetCoreInvMat.EntityModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreInvMat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class InventariosController : ControllerBase
    {
        private readonly InventarioMatDbContext _context;

        public InventariosController(InventarioMatDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return StatusCode(200, await _context.Inventario.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int? id)
        {
            if (id == null)
            {
                return StatusCode(400, "Bad Request");
            }

            Inventario model = await _context.Inventario.FindAsync(id);

            if (model == null)
            {
                return StatusCode(404, "Not Found");
            }

            return StatusCode(200,model);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Inventario model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400,"Bad Request");
            }

            await _context.Inventario.AddAsync(model);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        public async Task<IActionResult> Update(Inventario model)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400,"Bad Request");
            }

            Inventario modelEj = await _context.Inventario.FindAsync(model.Id);

            if (modelEj == null)
            {
                return StatusCode(404, "Not Found");
            }

            modelEj.Name = model.Name;
            modelEj.Symbol = model.Symbol;
            modelEj.Weight = model.Weight;

            _context.Update(modelEj);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(400,"Bad Request");
            }

            Inventario model = await _context.Inventario.FindAsync(id);

            if (model == null)
            {
                return StatusCode(404, "Not Found");
            }

            _context.Remove(model);
            await _context.SaveChangesAsync();
            return StatusCode(200);
        }

        
    }
}