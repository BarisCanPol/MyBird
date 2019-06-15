using MyBird.Model.Option;
using MyBird.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBird.Service.Option
{
   public  class BirdCommentService: ServiceBase<BirdComment>
    {

        public List<BirdComment> GetArticleComment (Guid id)
        {
            return GetDefault(x => x.BirdTweetID == id);
        }

        public int GetCommnentCount(Guid id)
        {
            return GetDefault(x => x.BirdTweetID == id).Count;
        }
    }
}
