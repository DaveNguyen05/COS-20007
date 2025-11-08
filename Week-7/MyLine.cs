using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _x1, _y1;

        public MyLine() : this(Color.Red, 0f, 0f, 200f, 200f)
        {
        }

        public MyLine(Color color, float startX, float startY, float endX, float endY) : base(color)
        {
            X = startX;
            Y = startY;
            _x1 = endX;
            _y1 = endY;
        }

        public override void Draw()
        {
            if (Selected == true)
            {
                DrawOutline();
            }
            SplashKit.DrawLine(_color, _x1, _y1, X, Y);
        }

        public override bool IsAt(Point2D pt)
        {
            return SplashKit.PointOnLine(pt, SplashKit.LineFrom(_x1, _y1, X, Y));
        }

        public override void DrawOutline()
        {
            SplashKit.DrawCircle(Color.Black, _x1, _y1, 5);
            SplashKit.DrawCircle(Color.Black, X, Y, 5);
        }
        
        public override void ScaleDown() //Scale down the line.
        {
            float centerX = (X + _x1) / 2; //Center point of the line
            float centerY = (Y + _y1) / 2;

            float deltaX1 = X - centerX; // Vectors from center to endpoints
            float deltaY1 = Y - centerY;
            float deltaX2 = _x1 - centerX;
            float deltaY2 = _y1 - centerY;
            
            X = centerX + (deltaX1 * 0.9f); //Scale down the vectors by 10%.
            Y = centerY + (deltaY1 * 0.9f);
            _x1 = centerX + (deltaX2 * 0.9f);
            _y1 = centerY + (deltaY2 * 0.9f);
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(_x1);
            writer.WriteLine(_y1);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            _x1 = reader.ReadSingle();
            _y1 = reader.ReadSingle();
        }
    }
}