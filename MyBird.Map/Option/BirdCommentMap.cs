using MyBird.Core.Map;
using MyBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Map.Option
{

    public class BirdCommentMap : CoreMap<BirdComment>
    {
        public BirdCommentMap()
        {
            ToTable("dbo.BirdComments");
            Property(a => a.CommentContent).HasMaxLength(40).IsOptional();

            HasRequired(a => a.BirdTweet).WithMany(a => a.BirdComments).HasForeignKey(a => a.BirdTweetID).WillCascadeOnDelete(false);

            HasRequired(a => a.BirdUser).WithMany(a => a.BirdComments).HasForeignKey(a => a.BirdUserID).WillCascadeOnDelete(false);

        }
    }
}
