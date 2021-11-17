using System;
using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    class Square:Rectangle
    {
        int length;

        public Square() : base()
        {

        }

        public Square(Color color, int x, int y, int length) : base(color, x, y, length, length)
        {
            this.length = length;
        }

        public override void set(Color color, params int[] list)
        {
            base.set(color, list[0], list[1], list[2], list[2]);
            this.length = list[2];
        }

        public override void draw(Graphics g)
        {
            base.draw(g);
        }
    }
}
