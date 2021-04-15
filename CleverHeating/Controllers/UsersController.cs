using CleverHeating.Models;
using CleverHeating.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleverHeating.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext _context;


        public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _userManager.Users.ToListAsync();
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        [HttpGet("GetUserSubscribes/{id}")]
        public async Task<ActionResult<User>> GetUserSubscribes(string id)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (user == null)
                return NotFound();
            List<Subscribe> subscribes = await _context.Subscribe.Where(s => s.UserId == id).ToListAsync();
            return new ObjectResult(subscribes);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<User>> Post(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Email = model.Email,
                    UserName = model.Email,
                    Name = model.UserName,
                    Surname = model.UserSurname,
                    PhoneNumber = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    return Ok(user);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<User>> Put(UserInfoViewModel model)
        {
            User user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.Email = model.Email;
                user.Name = model.UserName;
                user.Surname = model.UserSurname;
                user.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return Ok(user);
                }
                else
                    return BadRequest();
            }
            else
                return BadRequest();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return Ok(user);
        }
    }
}
