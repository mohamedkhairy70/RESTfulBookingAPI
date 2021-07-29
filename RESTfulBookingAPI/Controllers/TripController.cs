using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTfulBookingAPI.Models;
using RESTfulBookingAPI.Models.Domain;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly BookingContext context;
        private readonly ILogger<TripController> logger;
        private readonly IWebHostEnvironment environment;

        public TripController(BookingContext context, ILogger<TripController> logger,
                                IWebHostEnvironment environment)
        {
            this.context = context;
            this.logger = logger;
            this.environment = environment;
        }

        // GET: Trips
        // if Not connection Error Return Successed and List Of Trips
        // api/Trip/Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var users = await work.Trip.All();
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Trips : {ex.Message}");
                return BadRequest("Faild to get Trips");
            }

        }

        // GET: Trip
        // if Not connection Error Return Successed and One Of Trips
        // api/Trip/Get/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var Trips = await work.Trip.GetId(Id);
                    return Ok(Trips);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Trips : {ex.Message}");
                return BadRequest("Faild to get Trips");
            }

        }

        // Post: Trip
        // if Not connection Error Return Created Add New Trip
        // api/Trip/Post and Call New Trip FromBody
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Trip trip)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var work = new UnitOfWork(context))
                    {

                        await work.Trip.Add(trip);
                        var result = await work.Commet();
                        if (result == 1)
                        {
                            return Created("", trip);
                        }
                        else
                        {
                            logger.LogError($"Faild to Add Trip : {trip.Name}");
                            return BadRequest("Faild to Add Trip");
                        }
                    }
                }
                else
                {
                    logger.LogError($"Faild to Add Trip : {trip.Name}");
                    return BadRequest("Faild to Add Trip");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Add Trip : {ex.Message}");
                return BadRequest("Faild to Add Trip");
            }

        }

        // Put: Trip
        // if Not connection Error Return Successed and Update Trip
        // api/Trip/Put and Call Trip FromBody
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Trip trip)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (trip.Id > 0)
                    {
                        using (var work = new UnitOfWork(context))
                        {
                            var AsyncTrip = await work.Trip.GetId(trip.Id);
                            if (AsyncTrip.Id > 0)
                            {
                                work.Trip.Update(trip);
                                var result = await work.Commet();
                                if (result == 1)
                                {
                                    return Ok(trip);
                                }
                            }
                        }
                    }
                    return BadRequest("Faild to Update Trip");
                }
                else
                {
                    logger.LogError($"Faild to Update Trip : {trip.Name}");
                    return BadRequest("Faild to Update Trip");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Update Trip : {ex.Message}");
                return BadRequest("Faild to Update Trip");
            }

        }


        // Delete: Trip
        // if Not connection Error Return NoContent and Delete Trip
        // api/Trip/Put and Call Trip FromBody
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Trip trip)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (trip.Id > 0)
                    {
                        using (var work = new UnitOfWork(context))
                        {
                            var AsyncTrip = await work.Trip.GetId(trip.Id);
                            if (AsyncTrip.Id > 0)
                            {
                                work.Trip.Delete(trip);
                                var result = await work.Commet();
                                if (result == 1)
                                {
                                    return NoContent();
                                }
                            }

                        }
                    }
                    return BadRequest("Faild to Delete Trip");

                }
                else
                {
                    logger.LogError($"Faild to Delete Trip : {trip.Name}");
                    return BadRequest("Faild to Delete Trip");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Delete Trip : {ex.Message}");
                return BadRequest("Faild to Delete Trip");
            }

        }

        // Post: Trip
        // Add File To Photos 
        // api/Trip/Put and Call Trip FromBody
        [Route("SaveFile")]
        [HttpPost]
        public IActionResult SaveFile()
        {
            try
            {
                var httpRequset = Request.Form;
                var postFile = httpRequset.Files[0];
                var fileName = postFile.FileName;
                var physicalPath = environment.ContentRootPath + "/Photos/" + fileName;

                using (var strem = new FileStream(physicalPath, FileMode.Create))
                {
                    postFile.CopyTo(strem);
                }
                return Ok(physicalPath);
            }
            catch
            {
                return BadRequest("Cannot Save Your Image");
            }
        }
    }
}
