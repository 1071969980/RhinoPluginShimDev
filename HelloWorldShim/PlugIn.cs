using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO : 更改命名空间
namespace HelloWorldShim
{

    #region Don't touch, you only need one

    public class Plugin : Rhino.PlugIns.PlugIn

    {
        public Plugin()
        {
            Instance = this;
        }


        public static Plugin Instance
        {
            get; private set;
        }


    }
    #endregion


}