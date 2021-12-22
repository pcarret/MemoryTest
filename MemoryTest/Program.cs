using Aleker.Blazor.Svg.Maths;

// System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();


Test t = new();

// See https://aka.ms/new-console-template for more information
Console.WriteLine($"Hello, RAM! ");
t.BigLoop(1);

Console.WriteLine($"Calling GC first time"); 
GC.Collect();

t.BigLoop(10);
Console.WriteLine($"Calling GC second time");

GC.Collect();
Console.WriteLine($"Press ESC to stop");

do
{
    while (!Console.KeyAvailable)
    {
        // Do something
    }
} while (Console.ReadKey(true).Key != ConsoleKey.Escape);

class Test 
{
    public void BigLoop(int factor)
    {
        int zoom = 1;
        SvgMatrix m = new SvgMatrix(/*1, 0, 0, 1, 100, 100*/);
        SvgPoint pt1 = new SvgPoint(100, 102);
        while (zoom++ < 10E6 * factor)
        {
            //SvgPoint pt = this.SVG1.TransformScreen2Svg(pt1);
            SvgPoint pt = m.Transform(pt1);
        }
    }
}    
 