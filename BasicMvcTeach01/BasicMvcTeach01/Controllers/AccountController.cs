using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BasicMvcTeach01.Models.Entities;
using BasicMvcTeach01.Models.ViewModel;

namespace BasicMvcTeach01.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(LoginModel loginModel)
        {
            // 取得北風會員帳號
            var northWindEntities = new NorthWindEntities();
            var member = northWindEntities.Member.FirstOrDefault(p => p.Account == loginModel.Account);

            // 判斷帳號是否存在
            if (member == null)
            {
                // 帳號不存在時回傳錯誤訊息
                ModelState.AddModelError(nameof(LoginModel.Account),"帳號不存在");
                return View();
            }

            if (member.Password != loginModel.Password)
            {
                ModelState.AddModelError(nameof(LoginModel.Password),"密碼錯誤");
                return View();
            }



            return View();
        }
    }
}