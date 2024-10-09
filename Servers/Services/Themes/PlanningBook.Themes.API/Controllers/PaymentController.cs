using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanningBook.Themes.Application.Services;

namespace PlanningBook.Themes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous] //TODO: TESTing
    public class PaymentController(StripePaymentService _paymentService) : ControllerBase
    {
        [HttpPost("create-checkout-session")]
        public async Task<ActionResult> CreateCheckoutSession()
        {
            //var session = _paymentService.CreateCheckoutSession(
            //   "https://yourdomain.com/payment/success?sessionId={CHECKOUT_SESSION_ID}",
            //   "https://yourdomain.com/payment/cancel?sessionId={CHECKOUT_SESSION_ID}"
            //);

            // Record the session in your DB
            //_context.PaymentRecords.Add(new PaymentRecord
            //{
            //    StripeSessionId = session.Id,
            //    Created = DateTime.UtcNow,
            //    Status = "Created"
            //});
            //_context.SaveChanges();

            var origin = $"{Request.Scheme}://{Request.Host}";

            var session = await _paymentService.Test(origin);

            return Ok(new { redirectUrl = session.Url });
        }

        //[HttpGet("success")]
        //public async Task<IActionResult> Success(string sessionId)
        //{
        //    //var paymentRecord = await _context.PaymentRecords.FirstOrDefaultAsync(p => p.StripeSessionId == sessionId);
        //    //if (paymentRecord != null)
        //    //{
        //    //    paymentRecord.Status = "Success";
        //    //    await _context.SaveChangesAsync();
        //    //}

        //    // Redirect to a success page or return success response
        //    return Ok("Payment successful.");
        //}

        //[HttpGet("cancel")]
        //public async Task<IActionResult> Cancel(string sessionId)
        //{
        //    //var paymentRecord = await _context.PaymentRecords.FirstOrDefaultAsync(p => p.StripeSessionId == sessionId);
        //    //if (paymentRecord != null)
        //    //{
        //    //    paymentRecord.Status = "Cancelled";
        //    //    await _context.SaveChangesAsync();
        //    //}

        //    // Redirect to a cancel page or return cancel response
        //    return Ok("Payment cancelled.");
        //}
    }
}
