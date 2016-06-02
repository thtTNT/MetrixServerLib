using MetrixServerLib.Core;
using MetrixServerLib.Core.Plugin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetrixServerLib
{
    public class Metrix : MetrixPlugin
    {
        internal static MetrixThreadPool ThreadPool { get; set; }

    }
}
