using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;


namespace Middleware.ImageHanlerMiddleware
{
    public class ImageRead:IImageRead
    {
        string connString = "Data Source = .\\SQLEXPRESS; Initial Catalog = ECommerceSimplifie; Integrated Security = True";

        public async Task<string> ReadImage(int? id)
        {
            ImageDefinitionHelper imageDefinition = null;
            if (id != null)
            {
                imageDefinition = await GetFluxImage(connString, (int)id);
            }

            return imageDefinition.Filename;
        }

        private async Task<ImageDefinitionHelper> GetFluxImage(string connString, int id)
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("Select PictureBinary,Mimetype,SeoFilename from Picture Where id=@id");


                    command.Parameters.Add(new SqlParameter("@id", id));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    //reader.Read();
                   await reader.ReadAsync();
                    return  new ImageDefinitionHelper() { Flux = reader.GetStream(0) as MemoryStream, TypeMime = reader.GetString(1), Filename = reader.GetString(2) };

                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
    }
}
