using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViopOrtalama.Entities.Enitities;

namespace ViopOrtalama.Repositories.Middleware
{
   public class CurrentUserMiddleware
    {
        private readonly RequestDelegate _next;
        internal object CurrentUser;

        public CurrentUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, UserManager<AppUser> userManager)
        {
            var currentUser = await userManager.GetUserAsync(context.User);

            // Veriyi isteğin Items'ına ekleyebilirsiniz.
            context.Items["CurrentUser"] = currentUser;

            await _next(context);
        }
    }
}
