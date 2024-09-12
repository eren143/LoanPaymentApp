using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AraOdemeController : ControllerBase
    {
        private readonly AraOdemeService _araOdemeService;
        private readonly AraOdemeContext _context;  
        public AraOdemeController(AraOdemeContext context, AraOdemeService araOdemeService)
        {
            _context = context;
           _araOdemeService = araOdemeService;
        }


        [HttpGet("calculate")]
        public async Task<ActionResult<OdemePlani>> CalculateAraOdeme(
            [FromQuery] double krediTutari,
            [FromQuery] int vade,
            [FromQuery] double faiz,
            [FromQuery] int ilkAraOdemeTaksitNo,
            [FromQuery] int araOdemeSikliği,
            [FromQuery] int araOdemeTutari)
        {
            Console.WriteLine($"Debug - Parameters: krediTutari: {krediTutari}, vade: {vade}, faiz: {faiz}, ilkAraOdemeTaksitNo: {ilkAraOdemeTaksitNo}, araOdemeSikliği: {araOdemeSikliği}, araOdemeTutari: {araOdemeTutari}");

            if (araOdemeSikliği == 0)
            {
                return BadRequest("araOdemeSikliği cannot be zero.");
            }

            // Perform the calculation logic for the payment plan
            var odemePlani = _araOdemeService.AraOdemePlaniOlustur(krediTutari, vade, faiz, ilkAraOdemeTaksitNo, araOdemeSikliği, araOdemeTutari);

                // Save the payment table to the database
            await _context.AddAsync(odemePlani);
            await _context.SaveChangesAsync();

            // Return the calculated payment plan
            return Ok(odemePlani);
        }
        [HttpGet("get/{id}")]
        public async Task<ActionResult<OdemePlani>> GetOdemePlani(int id)
        {
            // Validate the input
            if (id <= 0)
            {
                return BadRequest("Invalid ID.");
            }

            // Retrieve the payment plan from the database
                var odemePlani = await _context.AraOdemePlanlari
            .Include(o => o.Satirlar) // Eager load related data
            .FirstOrDefaultAsync(o => o.Id == id);

            // Check if the payment plan was found
            if (odemePlani == null)
            {
                return NotFound("Payment plan not found.");
            }

            // Return the payment plan
            return Ok(odemePlani);
        }

    }
}



