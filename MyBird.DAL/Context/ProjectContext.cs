using MyBird.Core.Entity;
using MyBird.Map.Option;
using MyBird.Model.Option;
using MyBird.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.DAL.Context
{
    public class ProjectContext :DbContext
    {
        public ProjectContext()
        {
            Database.Connection.ConnectionString = "Server=Leon;Database=MyBirdTest;UID=bcp;PWD=123;";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BirdLikeMap());
            modelBuilder.Configurations.Add(new BirdTweetMap());
            modelBuilder.Configurations.Add(new BirdUserMap());
            modelBuilder.Configurations.Add(new BirdCommentMap());

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<BirdUser> BirdUsers { get; set; }
        public DbSet<BirdTweet> BirdTweets { get; set; }
        public DbSet<BirdLike> BirdLikes  { get; set; }
        public DbSet<BirdComment> BirdComments { get; set; }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            string identity = WindowsIdentity.GetCurrent().Name;
            string computerName = Environment.MachineName;
            DateTime dateTime = DateTime.Now;
            string GetIp = RemoteIP.IpAddress;

            foreach (var item in modifiedEntries)
            {
                CoreEntity entity = item.Entity as CoreEntity;

                if (item.State == EntityState.Added)
                {
                    entity.CreatedUserName = identity;
                    entity.CreatedComputerName = computerName;
                    entity.CreatedDate = dateTime;
                    entity.CreatedIP = GetIp;
                }
                else if (item.State == EntityState.Modified)
                {
                    entity.ModifiedUserName = identity;
                    entity.ModifiedComputerName = computerName;
                    entity.ModifiedDate = dateTime;
                    entity.ModifiedIP = GetIp;
                }
            }
            return base.SaveChanges();
        }
    }
}
