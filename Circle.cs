using System;
using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    class Circle:Shape
    {
        int radius;

        public Circle() : base()
        {

        }

        public Circle(Color color, int x, int y, int radius) : base(color, x, y)
        {
            this.radius = radius;
        }

        public override void set(Color color, params int[] list)
        {
            base.set(color, list[0], list[1]);
            this.radius = list[2];
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(color);
            g.FillEllipse(b, x, y, radius * 2, radius * 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);
        }

        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }

        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return base.ToString()+" "+this.radius;
        }
    }
}
