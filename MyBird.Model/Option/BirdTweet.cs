using MyBird.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Model.Option
{
    public class BirdTweet : CoreEntity
    {
        public string TweetContent { get; set; }
        public string TweetImagePath { get; set; }
        public int TweetLike { get; set; }


        public Guid BirdUserID  { get; set; }
        public virtual BirdUser BirdUser  { get; set; }

        public virtual List<BirdLike> BirdLikes { get; set; }
        public virtual List<BirdComment> BirdComments { get; set; }
    }
}
