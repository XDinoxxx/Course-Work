﻿using Course.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security;

namespace Course.Controllers
{
    public class UserController : Controller
    {
        private readonly AddDbContext _dbContext;
        public UserController(AddDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(Users user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Autorithation","User");
        }

        public IActionResult Autorithation()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Autorithation(Users user)
        {
            int id = _dbContext.GetUserId(user);
            var foundUser = _dbContext.Users.Find(id);
            if(foundUser != null)
            {
                if(foundUser.role_id == 1)
                {
                    return RedirectToAction("AdminPage","Home");
                }
                else if(foundUser.role_id == 2)
                {
                    return RedirectToAction("TeacherPage", "Home");
                }
                else if (foundUser.role_id == 3)
                {
                    TempData["studentId"] = id;
                    return RedirectToAction("StudentPage", "Home");
                }
                else if (foundUser.role_id == 4)
                {
                    TempData["parentId"] = id;
                    return RedirectToAction("ParentPage", "Home");
                }
                else 
                { 
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Autorithation", "User");
            }
        }
    }
}