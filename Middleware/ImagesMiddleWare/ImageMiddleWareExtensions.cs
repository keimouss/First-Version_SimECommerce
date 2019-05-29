using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Middleware.ImagesHandler
{
    public static class ImagesMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ImagesMiddleWare>();
        }
    }
}
