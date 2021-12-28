using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ZA365Solutions.Platform.Common;

namespace StudentCourse.API.Helpers
{
    public class SecurityContextHelper
    {
        public static RequestContext GetCurrentRequestContext()
        {
            var subscriptionId = Guid.Empty.ToString();
            var emailAddress = "";
            var userId = string.Empty;


            if (subscriptionId != null && emailAddress != null && userId != null)
            {

                RequestContext context =
                   new RequestContext(Guid.NewGuid(), "", Guid.Empty)
                   {
                       UserEmail = "#"
                   };
                return context;

            }
            throw new UnauthorizedAccessException();

        }
    }
}
