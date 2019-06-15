using MyBird.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Model.Option
{
   public class BirdComment:CoreEntity
    {
        public string CommentContent { get; set; }

        public Guid BirdUserID { get; set; }
        public virtual BirdUser BirdUser { get; set; }

        public Guid BirdTweetID { get; set; }
        public virtual BirdTweet BirdTweet { get; set; }
    }
}
