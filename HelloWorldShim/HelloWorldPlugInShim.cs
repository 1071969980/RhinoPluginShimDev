using Rhino;
using Rhino.Commands;
using System;
using System.IO;
using System.Reflection;

//TODO : 更改命名空间为$"调试插件命名空间"+"Shim"
namespace HelloWorldShim
{
    //TODO : 更改类名为$"调试插件插件名称"+"Shim"
    public class HelloWorldPlugInShim
    {
        private static string PathToBinRhp;
        private static string PathToBinPdb;
        private static string PathToObjRhp;
        private static string PathToObjPdb;

        //TODO : 更改为调试插件的库路径
        static HelloWorldPlugInShim()
        {
            PathToBinRhp = @"F:\+Develop\ShimPluginCASE\HelloWorld\HelloWorld\bin\HelloWorld.rhp";
            PathToBinPdb = @"F:\+Develop\ShimPluginCASE\HelloWorld\HelloWorld\bin\HelloWorld.pdb";
            PathToObjRhp = @"F:\+Develop\ShimPluginCASE\HelloWorld\HelloWorld\obj\Debug\HelloWorld.rhp";
            PathToObjPdb = @"F:\+Develop\ShimPluginCASE\HelloWorld\HelloWorld\obj\Debug\HelloWorld.pdb";
        }
        public static Result Execute(string CommandClassName, RhinoDoc doc, RunMode mode)
        {
            if (File.Exists(PathToObjRhp)) { File.Delete(PathToObjRhp); }
            if (File.Exists(PathToObjPdb)) { File.Delete(PathToObjPdb); }

            Assembly asm = Assembly.Load(File.ReadAllBytes(PathToBinRhp), File.ReadAllBytes(PathToBinPdb));
            Object obj = asm.CreateInstance(CommandClassName);

            if (obj != null)
            {
                MethodInfo m = obj.GetType().GetMethod("RunCommand", BindingFlags.Instance | BindingFlags.NonPublic);

                return (Result)m.Invoke(obj, new Object[] { doc, mode });
            }
            else
                return Result.Failure;
        }
    }
}