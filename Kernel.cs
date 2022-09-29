
using System;
using Cosmos.Core.Memory;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;

namespace ThingGUI
{
    public class Kernel : Sys.Kernel
    {
        

        protected override void BeforeRun()
        {
            Console.WriteLine("Woops! ThingGUI hasn't booted properly.");

            Graphics.Canvas.Screen();
        }

        protected override void Run()
        {
            Heap.Collect();
            Graphics.Canvas.ScreenRefresh();
        }
    }
}
