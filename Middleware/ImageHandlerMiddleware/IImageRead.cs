using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Middleware.ImageHanlerMiddleware
{
    public interface IImageRead
    {
        Task<string> ReadImage(int? id);
    }
}
