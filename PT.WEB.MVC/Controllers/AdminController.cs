using Microsoft.AspNet.Identity;
using PT.BLL.AccountRepository;
using PT.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PT.WEB.MVC.Controllers
{
    [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var roles = MemberschipTools.NewRoleManager().Roles.ToList();
            var userManager = MemberschipTools.NewUserManager();
            var users = userManager.Users.ToList().Select(x => new Entity.ViewModel.UsersViewModel
            {
                Email = x.Email,
                Name = x.Name,
                RegisterDate = x.RegisterDate,
                Salary = x.Salary,
                Surname = x.Surname,
                UserId = x.Id,
                UserName = x.UserName,
                RoleId = x.Roles.FirstOrDefault().RoleId,
                RoleName =roles.FirstOrDefault(y=>y.Id==userManager.FindById(x.Id).Roles.FirstOrDefault().RoleId).Name
            }).ToList();

           
         
            return View(users);
        }


        public ActionResult EditUser(string id)
        {
            if (id==null)
                RedirectToAction("Index");
            List<SelectListItem> rolList = new List<SelectListItem>();
            var roles = MemberschipTools.NewRoleManager().Roles.ToList();
            roles.ForEach(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id

            });
            ViewBag.roles = rolList;
            var userManager = MemberschipTools.NewUserManager();
            var user = userManager.FindById(id);
            if (user == null)
                return RedirectToAction("Index");
            var model = new UsersViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                Surname=user.Surname,
                Name=user.Name,
                RegisterDate=user.RegisterDate,
                RoleId= user.Roles.FirstOrDefault().RoleId,

            };
            return View(model);
        }
    }
}