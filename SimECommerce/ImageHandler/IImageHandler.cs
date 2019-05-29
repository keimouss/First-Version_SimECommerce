using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimECommerce.ImagesHandler
{
    public interface IImageHandler
    {
        Task<ObjectResult> ReadImage(int? id);
    }
}
