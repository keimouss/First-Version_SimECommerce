using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Middleware.ImageHanlerMiddleware
{
    class ImageDefinitionHelper
    {
        public Stream Flux { get; set; }
        public string TypeMime { get; set; }
        public string Filename { get; set; }
    }
}
