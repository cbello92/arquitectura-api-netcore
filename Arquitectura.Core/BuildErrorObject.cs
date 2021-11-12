using System;
using System.Collections.Generic;
using System.Text;

namespace Arquitectura.Core
{
    public class BuildErrorObject
    {
        public string Property { get; set; }
        public List<string> Errors { get; set; }
    }
}
