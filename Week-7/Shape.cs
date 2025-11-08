using System.ComponentModel;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        protected Color _color;
        protected float _x;
        protected float _y;
        protected bool _selected;

        public Shape()
        {
            _color = Color.Azure;
            _x = 100f;
            _y = 100f;
        }

        public Shape(int param)
        {
            _color = Color.Azure;
            _x = 100f;
            _y = 100f;
        }

        public Shape(Color color)
        {
            _color = color;
            _x = 0.0f;
            _y = 0.0f;
        }

        public Shape(int param, double x, double y)
        {
            _x = (float)x;
            _y = (float)y;
            _color = Color.Azure;
        }

        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }

        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public abstract void DrawOutline();

        public abstract void Draw();

        public abstract Boolean IsAt(Point2D pt);

        public abstract void ScaleDown(); //Scale down the shape.

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _color = reader.ReadColor();
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
        }
    }
}