using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;

using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.Fonts;

namespace GlisseTonPiedBot.Modules
{
    class EditImage
    {
        private String imageLink;

        public EditImage(string imageLink)
        {
            this.imageLink = imageLink;
        }

        public String convertWebImage()
        {
            String fillChemin = "image/imgtmp.png";
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFile(imageLink, fillChemin);
                Console.WriteLine("DL de " + imageLink);
            }
            return fillChemin;
        }

        public String Brightness()
        {
            String EditFillChemin = "image / update.png";
            using (Image image = Image.Load(convertWebImage()))
            {
                image.Mutate(c => c.ProcessPixelRowsAsVector4(row =>
                {
                    for (int x = 0; x < row.Length; x++)
                    {
                        // We can apply any custom processing logic here
                        row[x] = Vector4.SquareRoot(row[x]);
                    }
                }));
                image.Save("image/update.png");
                // image.Save(outPath);
                return EditFillChemin;
            }
        }

        public String writeMessageOnImage(String text)
        {
            String EditFillChemin = "image / update.png";
            

            FontCollection collection = new FontCollection();
            FontFamily family = collection.Install("font/arial.ttf");
            

            using (Image image = Image.Load(convertWebImage()))
            {

                int fontSize = 1;
                

                while ((image.Width)/((text.Length)* fontSize) > 0)
                {
                    fontSize++;
                    Console.WriteLine(fontSize);
                }
                
                    Font font = family.CreateFont(fontSize*1, FontStyle.Italic);

                image.Mutate(x => x.DrawText(text, font, Color.Black, new PointF(10, 10)));

                image.Save("image/update.png");
                // image.Save(outPath);
                return EditFillChemin;
            }
        }


    }
}
