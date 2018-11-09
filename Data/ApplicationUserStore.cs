using Domain;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Data
{
    public class ApplicationUserStore : UserStore<User>
    {

        public ApplicationUserStore(PiContext context) : base(context)
        {
        }
    }
}
