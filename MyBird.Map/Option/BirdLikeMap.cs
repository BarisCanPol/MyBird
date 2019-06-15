using MyBird.Core.Map;
using MyBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Map.Option
{
    public class BirdLikeMap:CoreMap<BirdLike>
    {
        public BirdLikeMap()
        {
            ToTable("dbo.BirdLikes");
            Property(a => a.LikeNumber).IsOptional();

            HasRequired(a => a.BirdUser).WithMany(a => a.BirdLikes).HasForeignKey(a => a.BirdUserID).WillCascadeOnDelete(false);

            HasRequired(a => a.BirdTweet).WithMany(a => a.BirdLikes).HasForeignKey(a => a.BirdTweetID).WillCascadeOnDelete(false);
        }
    }
}
