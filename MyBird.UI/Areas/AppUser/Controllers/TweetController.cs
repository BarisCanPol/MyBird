using MyBird.Model.Option;
using MyBird.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBird.UI.Areas.AppUser.Controllers
{
    public class TweetController : Controller
    {
        // GET: AppUser/Tweet
        BirdTweetService _birdTweetService;
        BirdLikeService _birdLikeService;
        BirdCommentService _birdCommentService;
        BirdUserService _birdUserService;

        public TweetController()
        {
            _birdCommentService = new BirdCommentService();
            _birdLikeService = new BirdLikeService();
            _birdTweetService = new BirdTweetService();
            _birdUserService = new BirdUserService();

        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(BirdTweet data)
        {
            //System.Security.Principal.WindowsIdentity.GetCurrent().Name;(windows ismini)
            //if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated == true)
            //{
            //    AuthPrincipals auth_users = (AuthPrincipals)System.Web.HttpContext.Current.User;
            //    if (auth_users != null)
            //    {
            //        userid = Convert.ToInt32(auth_users.UserId);
            //    }
            //}

            string isim = Session["MemberFullName"].ToString();
            BirdUser birdUser = _birdUserService.GetByDefault(x => x.UserName == isim);
            //BirdTweet newTweet = new BirdTweet();
            //newTweet.TweetContent = data.TweetContent;
            data.Status = MyBird.Core.Enum.Status.Active;
            data.BirdUserID =birdUser.ID;
            _birdTweetService.Add(data);
            return Redirect("/AppUser/Home/Index");
            
        }

      

    }
}