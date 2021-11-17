using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicalProgrammingLanguage
{
    abstract class Shape:IShapes
    {
        protected Color color;
        protected int x, y;

        public Shape()
        {
            color = Color.Red;
            x = y = 100;
        }

        public Shape(Color color, int x, int y)
        {
            this.color = color;
            this.x = x;
            this.y = y;
        }

        public abstract void draw(Graphics g);
        public abstract double calcArea();
        public abstract double calcPerimeter();

        public  virtual void set(Color color, params int[] list)
        {
            this.color = color;
            this.x = list[0];
            this.y = list[1];
        }
        public override string ToString()
        {
            return base.ToString()+"    "+this.x+","+this.y+" : ";
        }
    }
}
