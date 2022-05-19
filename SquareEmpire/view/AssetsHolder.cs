using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SquareEmpire.view
{
    public class AssetsHolder
    {
        private readonly Dictionary<string, Image> _images;

        public AssetsHolder()
        {
            _images = LoadImages();
        }

        public Image GetImage(string imageId)
        {
            return _images[imageId];
        }

        public Dictionary<string, Image> GetAllImages()
        {
            return _images;
        }

        private static Dictionary<string, Image> LoadImages()
        {
            var solutionDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            var unitImagesDir = Path.Combine(solutionDir, "SquareEmpire", "assets", "images");
            return Directory.GetFiles(unitImagesDir).ToDictionary(Path.GetFileNameWithoutExtension, Image.FromFile);
        }
    }
}