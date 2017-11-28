using Microsoft.AspNet.Identity;
using PT.BLL.AccountRepository;
using PT.BLL.Setting;
using PT.Entity.IdentyModel;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PT.WEB.MVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var userManager = MemberschipTools.NewUserManager();
            var checkUser = userManager.FindByName(model.Username);
            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "Bu kullanıcı zaten kayıtlı!");
                return View(model);
            }//register işlemi yapılır
            var activationCode = Guid.NewGuid().ToString();
            ApplicationUser user = new ApplicationUser()
            {

                Name = model.Name,
                Surname=model.Surname,
                Email=model.Email,
                UserName=model.Username,
                ActivationCode=activationCode

            };
            var response=userManager.Create(user, model.Password);
            if (response.Succeeded)
              {
                string siteUrl = Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

                if (userManager.Users.Count()==1)
                {
                    userManager.AddToRole(user.Id, "Admin");

                    await SiteSettings.SendMail(new MailModel
                    {
                        To = user.Email,
                        Subject = "Hoşgeldin Sahip",
                        Message = "Sistemizi yöneteceğin için çok mutluyuz^^"

                    });



                }
                else
                {
                    userManager.AddToRole(user.Id,"Passive");

                    await SiteSettings.SendMail(new MailModel
                    {
                        To = user.Email,
                        Subject = "Personel Yönetimi-aktivasyon",
                        Message = $"Merhaba {user.UserName}, {user.Surname}</br> Hesabınızı aktifleştirmek için <a href='{siteUrl}/Account/Activation?code={activationCode}'> Akrtivasyon kodu</a>"


                    });

                }
                return RedirectToAction("Login", "Account");


            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kayıt işleminde bir hata oluştu");
                return View(model);

            }
            return View();
        }

    }
}