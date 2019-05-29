using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.ImagesHandler
{
    public class ImagesMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ImageMiddleWareOptions _options;

        public ImagesMiddleWare(RequestDelegate next,IOptions<ImageMiddleWareOptions> options)
        {
            // This is an HTTP Handler, so no need to store next
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync(GenerateResponse(context).ToString());
        }

        private async Task<string> WriteImage(ImageDefinition image)
        {
            string filename;
            try
            {
                var extension = "." + image.TypeMime.Split('/')[image.TypeMime.Split('/').Length - 1];
                filename = image.Filename + extension;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await image.Flux.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {

                return e.Message;
            }
            return filename;
        }


        private Stream GenerateResponse(HttpContext context)
        {
            //string connString = "Data Source = localhost; Initial Catalog = ECommerceSimplifie; Integrated Security = True";
            string connString = "Data Source = .\\SQLEXPRESS; Initial Catalog = ECommerceSimplifie; Integrated Security = True";
            int? id = int.Parse(context.Request.Query["id"]);
            ImageDefinition imageDefinition = null;
            if (id != null)
            {
                imageDefinition = GetFluxImage(connString, (int)id);
            }
            context.Response.ContentType = imageDefinition.TypeMime;
            context.Response.GetTypedHeaders().CacheControl =
            new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
            {
                Public = true

            };
            return imageDefinition.Flux;
        }


        internal class ImageDefinition
        {
            internal Stream Flux { get; set; }
            internal string TypeMime { get; set; }
            internal string Filename { get; set; }
        }



        private ImageDefinition GetFluxImage(string connString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("Select PictureBinary,Mimetype,SeoFilename from Picture Where id=@id");
                   

                    command.Parameters.Add(new SqlParameter("@id", id));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    reader.Read();
                    return new ImageDefinition() { Flux = reader.GetStream(0) as MemoryStream, TypeMime = reader.GetString(1),Filename= reader.GetString(2) };

                }
                catch (Exception)
                {
                    return null;
                }

            }
        }

        
    }
}

