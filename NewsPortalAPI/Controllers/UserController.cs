using Microsoft.AspNetCore.Mvc;
using NewsPortalAPI.Data;
using NewsPortalAPI.Models;

namespace NewsPortalAPI.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class UserController : Controller
        {
            private readonly ApplicationDbContext _context;
            public UserController(ApplicationDbContext context)
            {
                _context = context;
            }

            [HttpGet("GetAll")]
            public IActionResult GetAll()
            {
                var users = _context.User;
                return Ok(users);
            }

            [HttpGet("GetById")]
            public IActionResult GetById(int Id)
            {
                var user = _context.User.Find(Id);
                return Ok(user);
            }

            [HttpPost("Register")]
            public IActionResult Register(User user)
            {
                _context.User.Add(user);
            _context.SaveChanges();
                return Ok();
            }

            [HttpPost("UpdateUser")]
            public IActionResult UpdateUser(User user)
            {
                _context.User.Update(user);
            _context.SaveChanges(); 
                return Ok();
            }

            [HttpDelete("DeleteUser")]
            public IActionResult DeleteUser(int Id)
            {
            var deleterecord = _context.User.Find(Id);
            if (deleterecord == null)
            {
                return NotFound();
            }
            _context.User.Remove(deleterecord);
            _context.SaveChanges();
            return Ok("Deleted Successfully !");
        }

            [HttpGet("CheckLogin")]
            public IActionResult CheckLogin(string emailAddress, string password)
            {
                User user = new User
                {
                    EmailAddress = emailAddress,
                    Password = password
                };
               var userData = _context.User.Where
               (c => c.EmailAddress == user.EmailAddress && c.Password == user.Password).FirstOrDefault();
                if (userData == null)
                {
                    return Ok("User not exist");
                }
                else
                {
                    return Ok(userData);
                }

            }

        }
    }

