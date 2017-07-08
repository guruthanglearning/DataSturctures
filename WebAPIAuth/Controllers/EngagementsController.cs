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
        private async Task<IEnumerable<Engagement>> GetAllEngagements()
        {
            SAMWorkbenchDB_DEVEntities1 context = new SAMWorkbenchDB_DEVEntities1();
            return await context.Engagements.ToListAsync();
            
        }


        [Route("api/v1/Engagements/{id:int:min(1)}")]
        public async Task<Engagement> GetEngagements(int id)
        {
            SAMWorkbenchDB_DEVEntities1 context = new SAMWorkbenchDB_DEVEntities1();
            return await context.Engagements.Where(w=>w.EngagementId == id).FirstOrDefaultAsync();            
        }


        [Route("api/v1/Engagements/{search}")]
        public async Task<IEnumerable<Engagement>> GetEngagements(string search)
        {
            SAMWorkbenchDB_DEVEntities1 context = new SAMWorkbenchDB_DEVEntities1();
            return await context.Engagements.Where(w => w.EngagementName == search && (w.isDeleted == null || w.isDeleted.Value == false)).ToListAsync();
        }

        [Route("api/v1/Engagements/{*date:datetime}")]
        public async Task<IEnumerable<Engagement>> GetEngagements(DateTime date)
        {
            SAMWorkbenchDB_DEVEntities1 context = new SAMWorkbenchDB_DEVEntities1();
            return await context.Engagements.Where(w => w.CreatedOn >= date && (w.isDeleted == null || w.isDeleted.Value == false)).ToListAsync();
        }

    }
}
