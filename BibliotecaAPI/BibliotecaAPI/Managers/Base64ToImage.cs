using Microsoft.Extensions.Hosting.Internal;
using System.Diagnostics;

namespace BibliotecaAPI.Managers
{
    public class Base64ToImage
    {

        public string ConvertBase64(string base64Img,string imgName)
        {
            try
            {
                imgName = imgName.Replace(" ", "-");

                string[] extension = { "jpeg", "jpg", "png" };

                foreach (string ex in extension)
                {
                    if (base64Img.Contains(ex))
                    {
                        imgName += $".{ex}";
                    }
                }

                string UPLOAD_PATH =   $"/wwwroot/Portadas/{imgName}";
    
                string fileName = Environment.CurrentDirectory + UPLOAD_PATH;

                //fileName = fileName.Replace("~", "");
                string substring = string.Empty;
                if (base64Img.Contains(','))
                {
                    substring = base64Img.Split(',')[1];
                }
                else
                {
                    substring = base64Img;
                }

                

                byte[] imageBytes = Convert.FromBase64String(substring);
                File.WriteAllBytes(fileName, imageBytes);
                return imgName;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.ToString();
            }

        }


    }
}
