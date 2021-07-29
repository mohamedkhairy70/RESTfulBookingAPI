using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTfulBookingAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly BookingContext context;
        private readonly ILogger<ReservationsController> logger;

        public ReservationController(BookingContext context, ILogger<ReservationsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: Reservations
        // if Not connection Error Return Successed and List Of Reservations
        // api/Reservation/Get
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    ViewBag.Title = "Reservation List";
                    var reservations = await work.Reservation.All();
                    return View(reservations);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Reservation : {ex.Message}");
                return BadRequest("Faild to get Reservation");
            }

        }

    }
}
