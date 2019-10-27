using System;
using MXGP.Core;

namespace MXGP
{
    using Models.Motorcycles;

    public class StartUp
    {
        public static void Main(string[] args)
        {
         //TODO Add IEngine
         Engine engine = new Engine();
         engine.Run();
        }
    }
}
