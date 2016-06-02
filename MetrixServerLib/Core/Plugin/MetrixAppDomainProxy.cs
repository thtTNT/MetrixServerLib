using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MetrixServerLib.Core.Plugin
{
    public class MetrixAppDomainProxy : MarshalByRefObject
    {
        public Assembly GetAssembly(string assemblyPath)
        {
            return Assembly.LoadFile(assemblyPath);
        }
    }
}
