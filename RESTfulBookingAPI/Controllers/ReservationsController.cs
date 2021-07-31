using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTfulBookingAPI.Models;
using RESTfulBookingAPI.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly BookingContext context;
        private readonly ILogger<ReservationsController> logger;

        public ReservationsController(BookingContext context, ILogger<ReservationsController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: Reservations
        // if Not connection Error Return Successed and List Of Reservations
        // api/Reservation/Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var reservations = await work.Reservation.All();
                    return Ok(reservations);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Users : {ex.Message}");
                return BadRequest("Faild to get Users");
            }

        }

        // GET: Reservation
        // if Not connection Error Return Successed and One Of Reservation
        // api/Reservation/Get/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var reservations = await work.Reservation.GetId(Id);
                    return Ok(reservations);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Reservation : {ex.Message}");
                return BadRequest("Faild to get Reservation");
            }

        }

        // GET: Reservation
        // if Not connection Error Return Successed and List Of ReservationByName
        // api/Reservation/Get/GetNames
        [HttpGet("GetNames")]
        public async Task<IActionResult> GetNames()
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var ReservationList = await work.Reservation.All();
                    var ReservationNames = from user in ReservationList
                                    select new
                                    {
                                        Name = user.ReservationDate
                                    };
                    return new JsonResult(ReservationList);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Reservation : {ex.Message}");
                return BadRequest("Faild to get Reservation");
            }

        }

        // Post: Reservation
        // if Not connection Error Return Created Add New Reservation
        // api/Reservation/Post and Call New Reservation FromBody
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var work = new UnitOfWork(context))
                    {

                        await work.Reservation.Add(reservation);
                        var result = await work.Commet();
                        if (result == 1)
                        {
                            return Created("", reservation);
                        }
                        else
                            return BadRequest("Faild to Add reservation");

                    }
                }
                else
                {
                    logger.LogError($"Faild to Add reservation : {reservation.CustomerName}");
                    return BadRequest("Faild to Add reservation");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Add reservation : {ex.Message}");
                return BadRequest("Faild to Add reservation");
            }

        }

        // Put: Reservation
        // if Not connection Error Return Successed and Update Reservation
        // api/Reservation/Put and Call Reservation FromBody
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Reservation reservation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (reservation.Id > 0)
                    {
                        using (var work = new UnitOfWork(context))
                        {
                            work.Reservation.Update(reservation);
                            var result = await work.Commet();
                            if (result == 1)
                            {
                                return Ok(reservation);
                            }
                        }
                    }
                    return BadRequest("Faild to Update reservation");
                }
                else
                {
                    logger.LogError($"Faild to Update reservation");
                    return BadRequest("Faild to Update reservation");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Update reservation : {ex.Message}");
                return BadRequest("Faild to Update reservation");
            }

        }


        // Reservation: Users
        // if Not connection Error Return NoContent and Reservation User
        // api/Reservation/Put and Call Reservation FromBody
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Id > 0)
                    {
                        using (var work = new UnitOfWork(context))
                        {
                            var Asyncreservation = await work.Reservation.GetId(Id);
                            if (Asyncreservation != null)
                            {
                                work.Reservation.Delete(Asyncreservation);
                                var result = await work.Commet();
                                if (result == 1)
                                {
                                    return new JsonResult("Successed Delete");
                                }
                            }

                        }
                    }
                    return BadRequest("Faild to Delete reservation");

                }
                else
                {
                    logger.LogError($"Faild to Delete reservation");
                    return BadRequest("Faild to Delete reservation");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Delete reservation : {ex.Message}");
                return BadRequest("Faild to Delete reservation");
            }

        }
    }
}
