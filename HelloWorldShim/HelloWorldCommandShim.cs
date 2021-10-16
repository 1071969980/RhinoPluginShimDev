using Rhino;
using Rhino.Commands;
using Rhino.Geometry;
using Rhino.Input;
using Rhino.Input.Custom;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

//TODO : 更改命名空间为$"调试插件命名空间"+"Shim"
namespace HelloWorldShim
{
    //TODO : 更改类名为$"调试插件命令类名"+"Shim"
    public class HelloWorldCommandShim : Command
    {
        //TODO : 若有多个命令，复制以创建新类
        //TODO : 更改为调试插件的命名空间和命令名称
        static string pluginNameSpace = "HelloWorld";
        static string pluginCommandEnglishName = "HelloWorldCommand";
        public HelloWorldCommandShim()
        {
            // Rhino only creates one instance of each command class defined in a
            // plug-in, so it is safe to store a refence in a static property.
            Instance = this;
        }

        ///<summary>The only instance of this command.</summary>
        public static HelloWorldCommandShim Instance
        {
            get; private set;
        }

        ///<returns>The command name as it appears on the Rhino command line.</returns>
        public override string EnglishName
        {
            get { return pluginCommandEnglishName + "Shim"; }
        }

        protected override Result RunCommand(RhinoDoc doc, RunMode mode)
        {
            return HelloWorldPlugInShim.Execute(pluginNameSpace + "." + pluginCommandEnglishName, doc, mode);
        }
    }
}
