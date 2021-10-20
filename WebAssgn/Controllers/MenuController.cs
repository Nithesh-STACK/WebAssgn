using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssgn.KaniniModel;

namespace WebAssgn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        public static stationaryContext db=new stationaryContext();
        
       
        

        [HttpGet]
        public async Task<IActionResult> Getchaats()
        {
            return Ok(await db.Chaats.ToListAsync());
        }
        [HttpPut]
        [Route("{id}")]

        public async Task<ActionResult<Chaat>> UpdateBook(int id, Chaat b)
        {
            using (var db = new stationaryContext())
            {
                db.Entry(b).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return Ok(b);
            }
        }
        [HttpGet]
        [Route("drinks")]
        public async Task<IActionResult> Getdrinks()
        {
            return Ok(await db.Drinks.ToListAsync());
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Chaat>> GetBookById(int id)
        {
            Chaat b = await db.Chaats.FindAsync(id);
            return Ok(b);
        }
     
    }
}
