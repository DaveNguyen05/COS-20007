using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyEllipse : Shape
    {
        private int _EllipseWidth;
        private int _EllipseHeight;
        private float _EllipseX;
        private float _EllipseY;
        public MyEllipse() : this(Color.SandyBrown, 100f, 100f, 100, 50)
        {
        }

        public MyEllipse(Color color, float x, float y, int Width, int Height) : base(color)
        {
            _EllipseX = x;
            _EllipseY = y;
            _EllipseWidth = Width;
            _EllipseHeight = Height;
        }

        public int EllipseSize
        {
            get
            {
                return _EllipseWidth;
            }
            set
            {
                _EllipseWidth = value;
                _EllipseHeight = value;
            }
        }

        public int EllipseWidth
        {
            get
            {
                return _EllipseWidth;
            }
            set
            {
                _EllipseWidth = value;
            }
        }

        public int EllipseHeight
        {
            get
            {
                return _EllipseHeight;
            }
            set
            {
                _EllipseHeight = value;
            }
        }

        public override void Draw()
        {
            if (_selected == true)
            {
                DrawOutline();
            }
            SplashKit.FillEllipse(_color, _EllipseX, _EllipseY, _EllipseWidth, _EllipseHeight);
        }

        public override void DrawOutline()
        {
            SplashKit.DrawEllipse(Color.Black, _EllipseX, _EllipseY, _EllipseWidth, _EllipseHeight);
        }

        public override Boolean IsAt(Point2D pt)
        {
            bool check = SplashKit.PointInRectangle(pt.X, pt.Y, _EllipseX, _EllipseY, _EllipseWidth, _EllipseHeight);
            return check;
        }

        public override void ScaleDown() //Scale down the ellipse.
        {
            _EllipseWidth = (int)(_EllipseWidth * 0.9);
            _EllipseHeight = (int)(_EllipseHeight * 0.9);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Ellipse");
            base.SaveTo(writer);
            writer.WriteLine(_EllipseWidth);
            writer.WriteLine(_EllipseHeight);
        }
        
        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _EllipseWidth = reader.ReadInteger();
            _EllipseHeight = reader.ReadInteger();
        }
    }
}