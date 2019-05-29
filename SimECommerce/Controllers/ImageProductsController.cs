using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimECommerce.ImagesHandler;
using SimECommerce.Models;

namespace SimECommerce.Controllers
{
    
    public class ImageProductsController : Controller
    {
        private readonly IImageHandler _imageHandler;
        private readonly ECommerceSimplifieContext _context;

        public ImageProductsController(IImageHandler imageHandler,ECommerceSimplifieContext context)
        {
            _imageHandler = imageHandler;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ReadImage(int? id)
        {
            return await _imageHandler.ReadImage(id);
        }

        // GET: Pictures
        public async Task<IActionResult> Index()
        {

            var result = await _context.Picture.ToListAsync();
            List<int> pictureIds = result.Select(p => p.Id).ToList();
            return View(pictureIds);
        }

        //[HttpPost]
        //public IActionResult UploadImage(IList<IFormFile> files)
        //{
        //    IFormFile uploadedImage = files.FirstOrDefault();
        //    if (uploadedImage == null || uploadedImage.ContentType.ToLower().StartsWith("image/"))
        //    {
        //        using (ImageDBContext dbContext = new ImageDBContext())
        //        {
        //            MemoryStream ms = new MemoryStream();
        //            uploadedImage.OpenReadStream().CopyTo(ms);

        //            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);

        //            Models.Image imageEntity = new Models.Image()
        //            {
        //                Id = Guid.NewGuid(),
        //                Name = uploadedImage.Name,
        //                Data = ms.ToArray(),
        //                Width = image.Width,
        //                Height = image.Height,
        //                ContentType = uploadedImage.ContentType
        //            };

        //            dbContext.Images.Add(imageEntity);

        //            dbContext.SaveChanges();
        //        }
        //    }

        //    return RedirectToAction("Index");
        //}


        [HttpGet]
        public FileStreamResult ViewImage(int? id)
        {
           
            Picture picture = _context.Picture.FirstOrDefault(p => p.Id == id);
            MemoryStream ms = new MemoryStream(picture.PictureBinary);
            return new FileStreamResult(ms, picture.MimeType);

        }
    }
}