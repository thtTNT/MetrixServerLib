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
    /// <summary>
    /// 插件管理器
    /// </summary>
    public class MetrixPluginManager
    {
        protected readonly List<FileInfo> m_pluginFileList = new List<FileInfo>();


        public MetrixPluginManager()
        {
            
        }

        /// <summary>
        /// 从文件夹中获取所有插件文件列表
        /// </summary>
        /// <param name="folder"></param>
        /// <returns></returns>
        public List<FileInfo> DetectPluginFiles(DirectoryInfo dir)
        {
            List<FileInfo> files = new List<FileInfo>();
            List<FileInfo> pluginFiles = new List<FileInfo>();

            if (Directory.Exists(dir.FullName))
            {
                foreach (String fileName in Directory.GetFiles(dir.FullName, "*.dll"))
                {
                    files.Add(new FileInfo(fileName));
                }

                foreach(FileInfo file in files)
                {
                    if(this.IsFilePlugin(file))
                    {
                        pluginFiles.Add(file);
                    }
                }
            }


            return pluginFiles;
        }

        /// <summary>
        /// 获取插件文件列表
        /// </summary>
        /// <returns></returns>
        public List<FileInfo> GetPluginFileList()
        {
            return this.m_pluginFileList;
        }

        /// <summary>
        /// 文件是否为插件
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Boolean IsFilePlugin(FileInfo file)
        {
            MetrixAppDomain domain = new MetrixAppDomain(file.Name);
           
            Assembly assembly = domain.CreateInstanceAndUnwrap().GetAssembly(file.FullName);

            foreach (Type type in assembly.GetTypes())
            {
                if (type.Equals(typeof(MetrixPlugin)) && type.IsDefined(typeof(MetrixPluginInfo)))
                {
                    domain.Unload();
                    return true;
                }
            }

            return false;
        }

    }
}
