using MyBird.Model.Option;
using MyBird.UI.Areas.AppUser.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBird.UI.Areas.AppUser.Models.VM
{
    public class TweetListVM
    {
        public TweetListVM()
        {
            BirdUsers = new List<BirdUser>();
            BirdComments = new List<BirdComment>();
            BirdLikes = new List<BirdLike>();
            BirdTweets = new List<BirdTweet>();
            //BirdUser = new BirdUserDTO();

            BirdTweet = new BirdTweet();
            BirdUser = new BirdUser();


        }
        public List<BirdUser> BirdUsers { get; set; }
        public List<BirdComment> BirdComments { get; set; }
        public List<BirdLike> BirdLikes { get; set; }
        public List<BirdTweet> BirdTweets { get; set; }
        //public BirdUserDTO BirdUser { get; set; }

         public BirdTweet BirdTweet { get; set; }
        public BirdUser BirdUser { get; set; }

        public int TweetLike { get; set; }
        //public int CommentCount { get; set; }
    }
}