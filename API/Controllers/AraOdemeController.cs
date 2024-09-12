using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Services;
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
        public ActionResult<OdemePlani> CalculateAraOdeme(
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
            OdemePlani odemePlani = _araOdemeService.AraOdemePlaniOlustur(krediTutari, vade, faiz, ilkAraOdemeTaksitNo, araOdemeSikliği, araOdemeTutari);

            // Return the calculated payment plan
            return Ok(odemePlani);
        }

    }
}



