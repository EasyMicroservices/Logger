using System;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("EasyMicroservices.Logger.Serilog")]

namespace EasyMicroservices.Logger.Models
{
    internal class ExtractedLogInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public Exception[] Exceptions { get; set; }
        public string[] Messages { get; set; }
        public object[] Objects { get; set; }

        public bool HasExceptions
        {
            get
            {
                return Exceptions.HasAny();
            }
        }
    }
}
