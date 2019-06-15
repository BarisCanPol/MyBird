using MyBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyBird.UI.Areas.AppUser.Models.DTO
{
    public class BirdUserDTO
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string Follower { get; set; }
        public string Following { get; set; }
        public string Info { get; set; }

       public virtual ICollection<BirdTweet> BirdTweets { get; set; }
            

        
    }
}