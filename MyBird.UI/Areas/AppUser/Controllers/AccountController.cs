using MyBird.Model.Option;
using MyBird.Service.Option;
using MyBird.UI.Areas.AppUser.Models.VM;
using MyBird.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBird.UI.Areas.AppUser.Controllers
{
    public class AccountController : Controller
    {
        BirdUserService _birdUserService;

        public AccountController()
        {
            _birdUserService = new BirdUserService();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(BirdUser data,HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath= UploadedImagePaths[0];

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {
                data.ImagePath = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                data.XSmallUserImage = UploadedImagePaths[1];
                data.CruptedUserImage = UploadedImagePaths[2];
            }

            data.Status = MyBird.Core.Enum.Status.Active;
            _birdUserService.Add(data);
            return Redirect("/AppUser/Account/Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credentials)
        {
            if (ModelState.IsValid)
            {
                if (_birdUserService.CheckCredentials(credentials.UserName,credentials.Password)  )
                {
                    BirdUser user = _birdUserService.FindByUserName(credentials.UserName);
                    string cookie = user.UserName;
                    FormsAuthentication.SetAuthCookie(cookie, true);
                    if (user.Status == MyBird.Core.Enum.Status.Active)
                    {
                        Session["MemberImagePath"] = user.ImagePath;
                        Session["MemberFullName"] = user.UserName;
                        Session["ID"] = user.ID;
                        return Redirect("/AppUser/Home/Index");
                    }
                    else
                    {
                        ViewData["error"] = "Kullanıcı adı veya şifre yanlış";
                    }
                }

                return View();
            }
            return View();
        }
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/AppUser/Account/Login");
        }
        
    }
}