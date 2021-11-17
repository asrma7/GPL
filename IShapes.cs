using System.Drawing;

namespace GraphicalProgrammingLanguage
{
    interface IShapes
    {
        void set(Color c, params int[] list);
        void draw(Graphics g);
        double calcArea();
        double calcPerimeter();
    }
}
