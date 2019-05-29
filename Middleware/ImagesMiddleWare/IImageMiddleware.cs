using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.ImagesHandler
{
    public interface IImagesMiddleware
    {
        Task<string> DownloadImage(HttpContext context);
    }
}
