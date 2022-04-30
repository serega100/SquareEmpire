using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace SquareEmpire.model.image
{
    public static class UnitImages
    {
        private static readonly Dictionary<string, Image> _images;

        static UnitImages()
        {
            var solutionDir = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..\\..\\..\\..\\"));
            var projectDir = Path.Combine(solutionDir, "SquareEmpire");
            var unitImagesDir = Path.Combine(projectDir, "assets", "images", "units");
            _images = Directory.GetDirectories(unitImagesDir)
                .SelectMany(Directory.GetFiles)
                .ToDictionary(Path.GetFileNameWithoutExtension, Image.FromFile);
        }

        public static Image Get(string unitClassName)
        {
            return _images[unitClassName];
        }
    }
}