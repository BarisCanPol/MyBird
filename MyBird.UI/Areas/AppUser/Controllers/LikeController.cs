using MyBird.Model.Option;
using MyBird.Service.Option;
using MyBird.UI.Areas.AppUser.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBird.UI.Areas.AppUser.Controllers
{
    public class LikeController : Controller
    {
        // GET: AppUser/Like
        public ActionResult Index()
        {
            return View();
        }

        BirdUserService _birdUserService;
        BirdLikeService _birdLikeService;
        BirdTweetService _birdTweetService;

        public LikeController()
        {
            _birdTweetService = new BirdTweetService();
            _birdLikeService = new BirdLikeService();
            _birdUserService = new BirdUserService();
        }

        public JsonResult AddLike(Guid id)
        {
            BirdUser user = _birdUserService.GetByDefault(x => x.UserName == User.Identity.Name);

            BirdLike like = new BirdLike();


            like.BirdUserID = user.ID;
            like.BirdTweetID = id;

            JsonLikeVM jr = new JsonLikeVM();
            try
            {
                like.BirdTweet.TweetLike++;
                _birdLikeService.Add(like);
                jr.isSuccess = true;
                jr.userMessage = "Beğenildi.";

            }
            catch (Exception)
            {
                jr.isSuccess = false;
                jr.userMessage = "Bir hata oluştu.";
            }

            return Json(jr, JsonRequestBehavior.AllowGet);


        }

        //public string LikeThis(Guid id)
        //{
        //    BirdTweet art = _birdTweetService.GetByDefault(x => x.ID == id);
        //    if (User.Identity.IsAuthenticated || Session["MemberFullName"] != null)
        //    {
        //        var Username = Session["MemberFullName"].ToString();
        //        BirdUser m = _birdUserService.GetByDefault(x => x.UserName == Username);
        //        art.TweetLike++;
        //        BirdLike like = new BirdLike();

        //        like.BirdTweetID = id;
        //        like.BirdUserID = m.ID;
        //        //like.LikedDate = DateTime.Now;
        //        //like.Liked = true;
        //        _birdLikeService.Add(like);


        //    }

        //    return art.TweetLike.ToString();
        //}
        //public string UnlikeThis(Guid id)
        //{
        //    BirdTweet art = _birdTweetService.GetByDefault(x => x.ID == id);
        //    if (User.Identity.IsAuthenticated || Session["MemberFullName"] != null)
        //    {
        //        var username = Session["MemberFullName"].ToString();
        //        BirdUser m = _birdUserService.GetByDefault(x => x.UserName == username);
        //        BirdLike l = _birdLikeService.GetByDefault(x => x.BirdTweetID == id && x.BirdUserID == m.ID);
        //        art.TweetLike--;
        //        _birdLikeService.Remove(l);


        //    }
        //    return art.TweetLike.ToString();
        //}

    }
}