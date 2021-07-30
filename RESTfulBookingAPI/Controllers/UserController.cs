using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RESTfulBookingAPI.Models;
using RESTfulBookingAPI.Models.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfulBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookingContext context;
        private readonly ILogger<UserController> logger;

        public UserController(BookingContext context, ILogger<UserController> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: Users
        // if Not connection Error Return Successed and List Of Users
        // api/User/Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var users = await work.User.All();
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get Users : {ex.Message}");
                return BadRequest("Faild to get Users");
            }

        }

        // GET: User
        // if Not connection Error Return Successed and One Of User
        // api/User/Get/5
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var users = await work.User.GetId(Id);
                    return Ok(users);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get User : {ex.Message}");
                return BadRequest("Faild to get User");
            }

        }

        // GET: User
        // if Not connection Error Return Successed and List Of UserByName
        // api/User/Get/GetNames
        [HttpGet("GetNames")]
        public async Task<IActionResult> GetNames()
        {
            try
            {
                using (var work = new UnitOfWork(context))
                {
                    var UserList = await work.User.All();
                    var UserNames = from user in UserList
                                    select new
                                    {
                                        Name = user.Email
                                    };
                    return Ok(UserNames);
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to get User : {ex.Message}");
                return BadRequest("Faild to get User");
            }

        }

        // Post: Users
        // if Not connection Error Return Created Add New User
        // api/User/Post and Call New User FromBody
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    using (var work = new UnitOfWork(context))
                    {
                        var IsExistsUser = work.User.Where(u => u.Email == user.Email);
                        if (IsExistsUser == null)
                        {
                            await work.User.Add(user);
                            var result = await work.Commet();
                            if (result == 1)
                            {
                                return Created("", user);
                            }
                        }
                        
                        return BadRequest("Failed to add user Please change your email This email is available");
                        
                    }
                }
                else
                {
                    logger.LogError($"Faild to Add User : {user.Email}");
                    return BadRequest("Faild to Add User");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Add User : {ex.Message}");
                return BadRequest("Faild to Add User");
            }

        }

        // Put: Users
        // if Not connection Error Return Successed and Update User
        // api/User/Put and Call User FromBody
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (user.Id > 0)
                    {
                        using (var work = new UnitOfWork(context))
                        {
                            var Asyncuser = await work.User.GetId(user.Id);
                            if (Asyncuser.Id > 0)
                            {
                                work.User.Update(user);
                                var result = await work.Commet();
                                if (result == 1)
                                {
                                    return Ok(user);
                                }
                            }
                        }
                    }
                    return BadRequest("Faild to Update User");
                }
                else
                {
                    logger.LogError($"Faild to Update User : {user.Email}");
                    return BadRequest("Faild to Update User");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Update User : {ex.Message}");
                return BadRequest("Faild to Update User");
            }

        }


        // Delete: Users
        // if Not connection Error Return NoContent and Delete User
        // api/User/Put and Call User FromBody
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
                            var Asyncuser = await work.User.GetId(Id);
                            if (Asyncuser.Id > 0)
                            {
                                work.User.Delete(Asyncuser);
                                var result = await work.Commet();
                                if (result == 1)
                                {
                                    return NoContent();
                                }
                            }

                        }
                    }
                    return BadRequest("Faild to Delete User");
                    
                }
                else
                {
                    logger.LogError("Faild to Delete User");
                    return BadRequest("Faild to Delete User");
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Faild to Delete User : {ex.Message}");
                return BadRequest("Faild to Delete User");
            }

        }
    }
}
