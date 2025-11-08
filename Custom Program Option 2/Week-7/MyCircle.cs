using System.Reflection;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public MyCircle()
        {
            _color = Color.BlueViolet;
            _radius = 40 + 20;
        }

        public MyCircle(Color color, float x, float y, int radius)
        {
            _color = color;
            _x = x;
            _y = y;
            _radius = radius;
        }

        public override void Draw()
        {
            if (Selected == true)
            {
                DrawOutline();
            }
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, _x, _y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointInCircle(pt.X, pt.Y, _x, _y, _radius);
        }

        public override void ScaleDown() //Scale down the circle.
        {
            _radius = (int)(_radius * 0.9);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(_radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _radius = reader.ReadInteger();
        }
    }
}