using Microsoft.AspNetCore.Mvc;
using API.Services;
using API.Data;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanPaymentController : ControllerBase
    {
        private readonly LoanCalculationService _loanCalculationService;
        private readonly AraOdemeContext _context;    

        // Inject both the dbContext and LoanCalculationService via constructor
        public LoanPaymentController(AraOdemeContext context, LoanCalculationService loanCalculationService)
        {
            _context = context;
            _loanCalculationService = loanCalculationService;
        }

        [HttpGet("calculate")]
        public ActionResult<LoanPaymentTable> Calculate(double krediTutari, double faiz, int vade)
        {
            try
            {
                // Calculate loan payment schedule
                var odemePlani = _loanCalculationService.CalculateLoanPaymentSchedule(krediTutari, faiz, vade);
                // Return the payment table
                return Ok(odemePlani);
            }
            catch (Exception ex)
            {
                // Return a bad request response with the error message
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
/*
        [HttpGet("calculate")]
        public async Task<ActionResult<LoanPaymentTable>> Calculate(double loanAmount, double interestRate, int durationMonths)
        {
            try
            {
                // Calculate loan payment schedule
                var paymentTable = _loanCalculationService.CalculateLoanPaymentSchedule(loanAmount, interestRate, durationMonths);

                // Save the payment table to the database
                await _context.AddAsync(paymentTable);
                await _context.SaveChangesAsync();

                // Return the payment table
                return Ok(paymentTable);
            }
            catch (Exception ex)
            {
                // Return a bad request response with the error message
                return BadRequest(new { message = ex.Message });
            }
        }



*/