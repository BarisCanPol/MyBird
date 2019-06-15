using MyBird.Core.Map;
using MyBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Map.Option
{
    public class BirdTweetMap : CoreMap<BirdTweet>
    {
        public BirdTweetMap()
        {
            ToTable("dbo.BirdTweets");
            Property(a => a.TweetContent).HasMaxLength(140).IsOptional();
            Property(a => a.TweetImagePath).IsOptional();

            HasRequired(x => x.BirdUser).WithMany(a => a.BirdTweets).HasForeignKey(a => a.BirdUserID).WillCascadeOnDelete(false);

            HasMany(a => a.BirdLikes).WithRequired(a => a.BirdTweet).HasForeignKey(a => a.BirdTweetID).WillCascadeOnDelete(false);

            HasMany(a => a.BirdComments).WithRequired(a => a.BirdTweet).HasForeignKey(a => a.BirdTweetID).WillCascadeOnDelete(false);
        }
    }
}
