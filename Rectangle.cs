using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    class Rectangle:Shape
    {
        int width, height;

        public Rectangle() : base()
        {

        }

        public Rectangle(Color color, int x, int y, int width, int height) : base(color, x, y)
        {
            this.width = width;
            this.height = height;
        }

        public override void set(Color color, params int[] list)
        {
            base.set(color, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black,2);
            SolidBrush b = new SolidBrush(color);
            g.FillRectangle(b, x, y, width, height);
            g.DrawRectangle(p, x, y, width, height);
        }

        public override double calcArea()
        {
            return width * height;
        }

        public override double calcPerimeter()
        {
            return 2 * (width + height);
        }

        public override string ToString()
        {
            return base.ToString()+" "+this.width+" "+this.height;
        }
    }
}
