using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
            if (!ModelState.IsValid)
            {
                return View();
            }

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


            // 登入憑證建立
            var ticket = new FormsAuthenticationTicket(
                    version: 1,
                    name: member.UserName,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddMinutes(10),
                    true, "",
                    FormsAuthentication.FormsCookiePath);
            // 加密登入憑證
            var encryptTicket = FormsAuthentication.Encrypt(ticket);
            // 將加密後的登入憑證轉為cookie型別
            var ticketCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
            // 加入cookie
            Response.Cookies.Add(ticketCookie);

            return View();
        }
    }
}