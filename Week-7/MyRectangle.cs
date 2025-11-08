using SplashKitSDK;

namespace ShapeDrawer
{

    public class MyRectangle : Shape
    {
        private int _width;
        private int _height;
        public MyRectangle()
        {
            _color = Color.SandyBrown;
            _x = 100f;
            _y = 100f;
            _width = 100 + 10;
            _height = 100 + 10;
        }

        public MyRectangle(Color color, float x, float y, int width, int height)
        {
            _color = color;
            _x = x;
            _y = y;
            _width = width;
            _height = height;
        }

        public int Size
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                _height = value;
            }
        }

        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
        
        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        public override void Draw()
        {
            if (_selected == true)
            {
                DrawOutline();
            }
            SplashKit.FillRectangle(_color, _x, _y, _width, _height);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawRectangle(Color.Black, _x - 5, _y - 5, _width + 10, _height + 10);
        }

        public override Boolean IsAt(Point2D pt)
        {
            bool check = SplashKit.PointInRectangle(pt.X, pt.Y, _x, _y, _width, _height);
            return check;
        }

        public override void ScaleDown() //Scale down the rectangle.
        {
            _width = (int)(_width * 0.9);
            _height = (int)(_height * 0.9);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(_width);
            writer.WriteLine(_height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _width = reader.ReadInteger();
            _height = reader.ReadInteger();
        }
    }
}