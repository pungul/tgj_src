using System.Collections.Generic;
using System.Web.Http;
using YesGuruji.Entity;
using System.Linq;
using System;

namespace YesGuruji.Controllers
{
    public class FeedBackController : ApiController
    {
        private YesGurujiContext objContext = new YesGurujiContext();

        // GET: api/FeedBack
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FeedBack/5
        public IEnumerable<tblFeedBack> Get(string id)
        {
            return objContext.tblFeedBacks.Where(x=> x.VideoId == id && x.IsDisplay == true).OrderBy(x=> x.isSort).Take(10).ToList();
        }

        // POST: api/FeedBack
        public bool Post([FromBody]tblFeedBack model)
        {
            try
            {
                //model.isSort = MaxFeedbackSortNo() + 1;
                model.IsDisplay = false;
                model.CreateDate = DateTime.UtcNow;
                objContext.tblFeedBacks.Add(model);
                objContext.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {
                
                throw;
            }
            return false;
        }

        // PUT: api/FeedBack/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FeedBack/5
        public void Delete(int id)
        {
        }

        //public int MaxFeedbackSortNo() {
        //    return objContext.tblFeedBacks.Max(x => x.isSort);
        //}
    }
}
