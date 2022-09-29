using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using IL2CPU.API.Attribs;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using Cosmos.System.Graphics.Fonts;

namespace ThingGUI.Graphics
{
    public class Canvas
    {
        [ManifestResourceStream(ResourceName = "ThingGUI.testcur.bmp")]
        static byte[] file;
        static Bitmap bmp = new(file);

        [ManifestResourceStream(ResourceName = "ThingGUI.wallpaper.bmp")]
        static byte[] wfile;
        static Bitmap wbmp = new(wfile);
        public static void ScreenRefresh()
        {
            try
            {

                KernelHelpers.canvas.DrawImageAlpha(bmp, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y);
                KernelHelpers.canvas.Display();
                KernelHelpers.canvas.Clear(Color.Red);
                KernelHelpers.canvas.DrawImage(wbmp, 0,0);
                string MouseXString = Cosmos.System.MouseManager.X.ToString();
                string MouseYString = Cosmos.System.MouseManager.Y.ToString();
                KernelHelpers.canvas.DrawString($"X: {MouseXString} Y: {MouseYString}", PCScreenFont.Default, new Pen(Color.Black), 0, 0);
                KernelHelpers.canvas.DrawFilledRectangle(new Pen (Color.Black), 308, 553, 800, 500);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred: " + e.Message);
                Sys.Power.Shutdown();
            }
        }
        public static void Screen()
        {
            KernelHelpers.canvas = new SVGAIICanvas(new Mode(800, 600, ColorDepth.ColorDepth32));
            KernelHelpers.canvas.Clear(Color.Black);


            Sys.MouseManager.ScreenWidth = 800;
            Sys.MouseManager.ScreenHeight = 600;

            Sys.MouseManager.X = (uint)((int)KernelHelpers.canvas.Mode.Columns / 2);
            Sys.MouseManager.Y = (uint)((int)KernelHelpers.canvas.Mode.Rows / 2);
        }
    }
}
