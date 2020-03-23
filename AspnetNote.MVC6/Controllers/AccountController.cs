using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.Models;
using Microsoft.AspNetCore.Mvc;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.ViewModel;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class AccountController : Controller
    {
        // GET: /<controller>/
        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //id, pw - 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetDBContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserId.Equals(model.UserId) &&
                        u.UserPassword.Equals(model.UserPassword));
                    if (user != null)
                    {
                        //로그인 성공
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.UserNo);
                        return RedirectToAction("LoginSuccess", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");

            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 회원가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                using (var db = new AspnetDBContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
