using Microsoft.AspNetCore.Mvc;
using Middleware.ImageHanlerMiddleware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimECommerce.ImagesHandler
{
    public class ImageHandler:IImageHandler
    {
        private readonly IImageRead _imageRead;
        public ImageHandler(IImageRead imageRead)
        {
            _imageRead = imageRead;
        }

        public async Task<ObjectResult> ReadImage(int? id)
        {
            var result = await _imageRead.ReadImage(id);

            return new ObjectResult(result);
        }

       
    }
}
