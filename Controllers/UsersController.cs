﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smart_E.Data;
using Smart_E.Models;
using Smart_E.Models.AdministrationViewModels;

namespace Smart_E.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
       
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await (
                from c in _context.Users
                join ur in _context.UserRoles
                    on c.Id equals ur.UserId
                    join r in _context.Roles
                    on ur.RoleId equals r.Id
                select new
                {
                    Id = c.Id,
                    Name = c.FirstName + " "+ c.LastName,
                    Email = c.Email,
                    Status = c.Status,
                    Role = r.Name,
                    RoleId = r.Id,

                }).ToListAsync();

            return Json(users);
        }
        public async Task<IActionResult> GetAllUserRoles()
        {
            var roles = await (
                from r in _context.Roles
                select new
                {
                    Id = r.Id,
                    Name = r.Name

                }).ToListAsync();

            return Json(roles);
        }

        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRolePostModal modal)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Id == modal.Id);
                if (user != null)
                {
                    /*var role = await _context.Roles.SingleOrDefaultAsync(x => x.Id == modal.Role);

                    if (role != null)
                    {
                        var userRole =
                            await _context.UserRoles.SingleOrDefaultAsync(x => x.RoleId == role.Id && x.UserId == user.Id);

                        if (userRole != null)
                        {

                        }
                    }
                    return BadRequest("Role is invalid");*/
                }
                return BadRequest("User is invalid");
            }

            return BadRequest("Modal is invalid");
        }

        public async Task<IActionResult> GetUser([FromQuery]string id)
        {
            var user = await (
                from c in _context.Users
                join ur in _context.UserRoles
                    on c.Id equals ur.UserId
                join r in _context.Roles
                    on ur.RoleId equals r.Id
                    where c.Id == id
                select new
                {
                    Id = c.Id,
                    Name = c.FirstName + " "+ c.LastName,
                    Role = r.Name,
                    RoleId = r.Id

                }).SingleOrDefaultAsync();

            return Json(user);
        }

        public async Task<IActionResult> DeleteUser([FromQuery]string id, [FromQuery]string roleId)
        {
            var user = await _context.UserRoles.SingleOrDefaultAsync(x => x.UserId == id && x.RoleId == roleId);

            if (user != null)
            {
                _context.UserRoles.Remove(user);
                await _context.SaveChangesAsync();
                return Json(user);
            }

            return BadRequest("User Not Found");
        }


    }
}
