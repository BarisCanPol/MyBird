using MyBird.Core.Map;
using MyBird.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Map.Option
{
   public class BirdUserMap : CoreMap<BirdUser>
    {
        public BirdUserMap()
        {
            ToTable("dbo.BirdUsers");
            Property(a => a.Email).IsOptional();
            Property(a => a.UserName).IsOptional();
            Property(a => a.Password).IsOptional();
            Property(a => a.Follower).IsOptional();
            Property(a => a.Following).IsOptional();
            Property(a => a.Info).HasMaxLength(100).IsOptional();
            Property(a => a.ImagePath).IsOptional();

            HasMany(a => a.BirdTweets).WithRequired(a => a.BirdUser).HasForeignKey(a => a.BirdUserID).WillCascadeOnDelete(false);

            HasMany(a => a.BirdLikes).WithRequired(a => a.BirdUser).HasForeignKey(a => a.BirdUserID).WillCascadeOnDelete(false);

            HasMany(a => a.BirdComments).WithRequired(a => a.BirdUser).HasForeignKey(a => a.BirdUserID).WillCascadeOnDelete(false);
        }
    }
}
