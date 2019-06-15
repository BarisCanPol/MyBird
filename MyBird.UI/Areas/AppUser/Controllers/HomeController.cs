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
    public class HomeController : Controller
    {
        // GET: AppUser/Home
        BirdUserService _birdUserService;
        BirdLikeService _birdLikeService;
        BirdTweetService _birdTweetService;
        BirdCommentService _birdCommentService;

        public HomeController()
        {
            _birdCommentService = new BirdCommentService();
            _birdLikeService = new BirdLikeService();
            _birdTweetService = new BirdTweetService();
            _birdUserService = new BirdUserService();

        }

        public ActionResult Index()
        {

            
            TweetListVM model = new TweetListVM();
            model.BirdTweets = _birdTweetService.GetActive();
            //if (data.BirdUserID == model.BirdTweets.BirdUserID)
            //{
            //   model.BirdUsers = _birdUserService.GetActive();

            //}//içeriğe erişemiyorum???
            model.BirdUsers = _birdUserService.GetActive();


            foreach (var item in model.BirdTweets)
            {
                model.BirdComments = _birdCommentService.GetDefault(x => x.BirdTweetID == item.ID).OrderByDescending(x => x.CreatedDate).Take(10).ToList();
                model.TweetLike = _birdLikeService.GetDefault(x => x.BirdTweetID == item.ID).Count();
                //model.CommentCount = _birdCommentService.GetDefault(x => x.BirdTweetID == item.ID).Count();
                /* model.BirdUsers = _birdTweetService.GetByDefault(x=> x.BirdUserID==item.BirdUserID);*/ //birduser eklenicek
               
            }
            return View(model);
        }
    }
}