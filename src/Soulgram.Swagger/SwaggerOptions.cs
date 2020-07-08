using System;
using System.Collections.Generic;
namespace Soulgram.Swagger
{
    public class SwaggerOptions
    {
        public string FileName { get; set; }

        public ApiDetailsOptions ApiDetails { get; set; }

        public string Route { get; set; }
    }
}
