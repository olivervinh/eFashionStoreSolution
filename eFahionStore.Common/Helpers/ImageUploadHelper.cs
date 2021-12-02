using eFashionStore.Model.Models.Catalogs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFahionStore.Common.Helpers
{
    public static class ImageUploadHelper
    {
        public static async Task<bool> ImagePostAsync(ICollection<IFormFile> files, int id, int title,ImageBlog imageBlog, ImageProduct imageProduct)
        {
            if (files != null)
            {
                var filesArray = files.ToArray();
                for (int i = 0; i < filesArray.Length; i++)
                {

                    if (filesArray[i].Length > 0)
                    {

                        var obj = CheckNullObject(imageBlog, imageProduct);

                        var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot/Images/list-image-blogs",
                        title + id + "." + filesArray[i].FileName.Split(".")[filesArray[i].FileName.Split(".").Length - 1]);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await filesArray[i].CopyToAsync(stream);
                        }

                        if (imageBlog != null)
                        {

                        }
                      

                    }
                }

                return true;
            }
            return false;
        } 

        public static object CheckNullObject(object firstObj, object secondObj)
        {
            if (firstObj !=null)
            {
                return firstObj;
            }
            else
            {
                return secondObj;
            }
        }
    }
}
