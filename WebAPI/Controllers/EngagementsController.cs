using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.DataAccess;
namespace WebAPI.Controllers
{      
    public class EngagementsController : ApiController
    {
        public IEnumerable<Engagement> GetAllEngagements()
        {
            SAMWorkbenchDB context = new SAMWorkbenchDB();            
            return context.Engagements;
            
        }

        public IEnumerable<Engagement> GetEngagements(int id)
        {
            SAMWorkbenchDB context = new SAMWorkbenchDB();
            return context.Engagements.Where(w=>w.EngagementId == id);
            
        }
    }
}
