using System;


namespace Aleker.Blazor.Svg.Maths
{
    /// <summary>
    /// https://swimburger.net/blog/dotnet/communicating-between-dotnet-and-javascript-in-blazor-with-in-browser-samples
    /// Do not add any other property otherwise js deserialization would not work
    /// THis class must remind very light
    /// </summary>
    public class SvgPoint
    {
        public SvgPoint() { }
        public SvgPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public SvgPoint(SvgPoint another)
        {
            this.x = another.x;
            this.y = another.y;
        }

        public static SvgPoint operator -(SvgPoint a, SvgPoint b)
        {
            return new SvgPoint(a.x - b.x, a.y - b.y);
        }
        public static SvgPoint operator -(SvgPoint pt)
        {
            return new SvgPoint(-pt.x, -pt.y);
        }

        public void Translate(SvgPoint point)
        {
            this.x += point.x;
            this.y += point.y;
        }
        public SvgPoint Translated(SvgPoint point)
        {
            return new SvgPoint(this.x + point.x, this.y + point.y);
        }

        public void Scale(SvgPoint scale)
        {
            this.x *= scale.x;
            this.y *= scale.y;
        }
        public SvgPoint Scaled(SvgPoint scale)
        {
            return new SvgPoint(this.x * scale.x, this.y * scale.y);
        }

        public double x { get; set; }
        public double y { get; set; }
    }

    /// <summary>
    /// https://www.w3.org/TR/SVGTiny12/svgudom.html#svg__SVGRect
    /// </summary>

    public class SvgMatrix
    {

        public SvgMatrix()
        {
        }
        public SvgPoint Transform(double x, double y)
        {
            return Transform(new SvgPoint(x, y));
        }
        public SvgPoint Transform(SvgPoint pt)
        {
            SvgPoint answer = new SvgPoint();

            System.Diagnostics.Debug.Assert(answer is not null);
            answer.x = m11 * pt.x + m12 * pt.y + m41;
            answer.y = m21 * pt.x + m22 * pt.y + m42;
            return answer;
        }

  

        public double m11 { get; set; }
        public double m12 { get; set; }
        public double m21 { get; set; }
        public double m22 { get; set; }
        public double m41 { get; set; }
        public double m42 { get; set; }
    }
}