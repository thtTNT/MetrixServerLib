using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MetrixServerLib.Core.Plugin
{
    public class MetrixAppDomain
    {
        protected readonly AppDomainSetup m_domainInfo = AppDomain.CurrentDomain.SetupInformation;
        protected readonly Evidence m_adevidence = AppDomain.CurrentDomain.Evidence;

        public AppDomain Domain { get; set; }

        public MetrixAppDomain(String name)
        {
            this.m_domainInfo.ApplicationName = name;
            this.m_domainInfo.ApplicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            this.Domain = AppDomain.CreateDomain(name, this.m_adevidence, this.m_domainInfo);
        }


        public void Unload()
        {
            AppDomain.Unload(this.Domain);
        }

        public MetrixAppDomainProxy CreateInstanceAndUnwrap()
        {
            return this.Domain.CreateInstanceAndUnwrap(
                typeof(MetrixAppDomainProxy).Assembly.FullName,
                typeof(MetrixAppDomainProxy).FullName) as MetrixAppDomainProxy;
        }

    }
}
