using MyBird.Model.Option;
using MyBird.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Service.Option
{
    public class BirdLikeService:ServiceBase<BirdLike>
    {
        public int GetLikeCount(Guid id)
        {
            return GetDefault(x => x.BirdTweetID == id).Count();
        }
        public List<BirdLike> GetArticleLikes(Guid id)
        {
            return GetDefault(x => x.BirdTweetID == id);
        }
    }
}
