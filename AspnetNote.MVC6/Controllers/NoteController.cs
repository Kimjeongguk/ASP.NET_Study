using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetNote.MVC6.DataContext;
using AspnetNote.MVC6.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspnetNote.MVC6.Controllers
{
    public class NoteController : Controller
    {
        // GET: /<controller>/
        /// <summary>
        /// 게시판 리스트 출력
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            using (var db = new AspnetDBContext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        public IActionResult Detail(int noteNo)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            using(var db = new AspnetDBContext())
            {
                var note = db.Notes.FirstOrDefault(n => n.NoteNo.Equals(noteNo));
                return View(note);
            }

        }
        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(Note model)
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {
                using (var db = new AspnetDBContext())
                {
                    db.Notes.Add(model);


                    if (db.SaveChanges() > 0)// commit
                    {
                        return Redirect("Index"); // 동일한컨트롤러로갈때
                    }
                }
                ModelState.AddModelError(string.Empty, "게시물을 저장할수 없습니다.");
            }
            return View(model);
        }
        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        /// <summary>
        /// 게시물삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안된 상태
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
    }
}
