using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPIAuth.DataAccess;
namespace WebAPI.Controllers
{      
    public partial class EngagementsController : ApiController
    {
        
        [Route("api/v2/Engagements/{id:int?}")]
        public async Task<Engagement> GetV2Engagements(int id = 9210)
        {
            SAMWorkbenchDB_DEVEntities1 context = new SAMWorkbenchDB_DEVEntities1();
            return await context.Engagements.Where(w => w.EngagementId == id).FirstOrDefaultAsync();
        }

        
    }
}
