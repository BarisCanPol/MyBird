using MyBird.Model.Option;
using MyBird.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBird.UI.Areas.AppUser.Controllers
{
    public class CommentController : Controller
    {
        // GET: AppUser/Comment
        public ActionResult Index()
        {
            return View();
        }
        BirdUserService _birdUserService;
        BirdCommentService _birdCommentService;
        public CommentController()
        {
            _birdUserService = new BirdUserService();
            _birdCommentService = new BirdCommentService();
        }
        public JsonResult AddComment(string userComment, Guid id)
        {
            BirdComment comment = new BirdComment();

            comment.BirdUserID = _birdUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            comment.BirdTweetID = id;
            comment.CommentContent = userComment;

            bool isAdded = false;
            try
            {
                _birdCommentService.Add(comment);
                isAdded = true;
            }
            catch (Exception)
            {

                isAdded = false;
            }
            return Json(isAdded, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetTweetComment(string id)
        {
            Guid tweetID = new Guid(id);

            BirdComment comment = _birdCommentService.GetLastOrDefault(x => x.BirdTweetID == tweetID);

            return Json(new
            {
                BirdUserImagePath = comment.BirdUser.ImagePath,
                UserName = comment.BirdUser.UserName,
                CreatedDate = comment.CreatedDate.ToString(),
                Content = comment.CommentContent
             }, JsonRequestBehavior.AllowGet );
               
        }
    }
}