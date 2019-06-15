using MyBird.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Model.Option
{
   public class BirdUser : CoreEntity
    {
        public enum Role
        {
            None = 0,           
            Member = 1
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }
        public string Follower { get; set; }
        public string Following { get; set; }
        public string Info { get; set; }

        public virtual List<BirdTweet> BirdTweets { get; set; }
        public virtual List<BirdLike> BirdLikes { get; set; }
        public virtual List<BirdComment> BirdComments { get; set; }
    }
}