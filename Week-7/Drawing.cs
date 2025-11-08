using System;
using ShapeDrawer;
using SplashKitSDK;

public class Drawing
{
    private List<Shape> _shapes;
    private Color _background;
    private Random _random;
    public Drawing()
    {
        _shapes = new List<Shape>();
        _background = Color.White;
        _random = new Random();
    }

    public Drawing(Color background)
    {
        _shapes = new List<Shape>();
        _background = background;
        _random = new Random();
    }

    public List<Shape> SelectedShapes
    {
        get
        {
            List<Shape> result = new List<Shape>();
            foreach (Shape s in _shapes)
            {
                if (s.Selected == true)
                {
                    result.Add(s);
                }
            }
            return result;
        }
    }

    public int ShapeCount
    {
        get
        {
            return _shapes.Count;
        }
    }

    public Color Background
    {
        get
        {
            return _background;
        }
        set
        {
            _background = value;
        }
    }

    public void Draw()
    {
        SplashKit.ClearScreen(_background);
        foreach (Shape s in _shapes)
        {
            s.Draw();
            if (s.Selected == true)
            {
                s.DrawOutline();
            }
        }
    }

    public void SelectedShapesAt(Point2D pt)
    {
        foreach (Shape s in _shapes)
        {
            if (s.IsAt(pt) == true)
            {
                s.Selected = s.IsAt(pt);
            }
        }
    }

    public void AddShape(Shape s)
    {
        _shapes.Add(s);
    }

    public void RemoveShape(Shape s)
    {
        _shapes.Remove(s);
    }

    public void RemoveLastShape()
    {
        if (_shapes.Count > 0)
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }
    }

    public void GenerateRandomShapes()
    {
        int numberOfShapes = _random.Next(5, 15); //Random number between 5 and 14.
        
        for (int i = 0; i < numberOfShapes; i++)
        {
            int shapeType = _random.Next(0, 3); //0 = Rectangle, 1 = Circle, 2 = Line.
            Shape newShape;
            float randomX = _random.Next(50, 650);
            float randomY = _random.Next(50, 650);
            Color randomColor = SplashKit.RandomColor();
            
            switch (shapeType)
            {
                case 0: //Rectangle.
                    int width = _random.Next(30, 100);
                    int height = _random.Next(30, 100);
                    newShape = new MyRectangle(randomColor, randomX, randomY, width, height);
                    break;
                case 1: //Circle.
                    int radius = _random.Next(20, 60);
                    newShape = new MyCircle(randomColor, randomX, randomY, radius);
                    break;
                case 2: //Line.
                    float endX = _random.Next(50, 650);
                    float endY = _random.Next(50, 650);
                    newShape = new MyLine(randomColor, randomX, randomY, endX, endY);
                    break;
                default:
                    newShape = new MyRectangle(randomColor, randomX, randomY, 50, 50);
                    break;
            }
            
            AddShape(newShape);
        }
    }

    public void RandomizeAllColors() //Randomize colors of all shapes.
    {
        foreach (Shape s in _shapes)
        {
            s.Color = SplashKit.RandomColor();
        }
    }

    public void DrawDAVE() //Draw the name "DAVE" using lines and rectangles.
    {
        float startX = 150f;
        float startY = 300f;
        float letterWidth = 80f;
        float letterSpacing = 90f;

        DrawLetterD(startX, startY);

        DrawLetterA(startX + letterSpacing, startY);

        DrawLetterV(startX + letterSpacing * 2, startY);

        DrawLetterE(startX + letterSpacing * 3, startY);
    }

    private void DrawLetterD(float x, float y)
    {
        MyLine leftLine = new MyLine(Color.Red, x, y, x, y + 100); //Left vertical line.
        AddShape(leftLine);

        MyLine topLine = new MyLine(Color.Red, x, y, x + 50, y); //Top horizontal line.
        AddShape(topLine);

        MyLine bottomLine = new MyLine(Color.Red, x, y + 100, x + 50, y + 100); //Bottom horizontal line.
        AddShape(bottomLine);

        MyCircle curve = new MyCircle(Color.Red, x + 50, y + 50, 50); //Semi-circle for the curved part.
        AddShape(curve);
    }

    private void DrawLetterA(float x, float y)
    {
        MyLine leftLine = new MyLine(Color.Blue, x, y + 100, x + 30, y); //Left diagonal line.
        AddShape(leftLine);

        MyLine rightLine = new MyLine(Color.Blue, x + 30, y, x + 60, y + 100); //Right diagonal line.
        AddShape(rightLine);

        MyLine middleLine = new MyLine(Color.Blue, x + 15, y + 60, x + 45, y + 60); //Middle horizontal line.
        AddShape(middleLine);
    }

    private void DrawLetterV(float x, float y)
    {
        MyLine leftLine = new MyLine(Color.Green, x, y, x + 30, y + 100); //Left diagonal line.
        AddShape(leftLine);

        MyLine rightLine = new MyLine(Color.Green, x + 30, y + 100, x + 60, y); //Right diagonal line.
        AddShape(rightLine);
    }

    private void DrawLetterE(float x, float y)
    {
        MyLine leftLine = new MyLine(Color.Purple, x, y, x, y + 100); //Left vertical line.
        AddShape(leftLine);

        MyRectangle topBar = new MyRectangle(Color.Purple, x, y, 50, 10); //Top horizontal bar.
        AddShape(topBar);

        MyRectangle middleBar = new MyRectangle(Color.Purple, x, y + 45, 40, 10); //Middle horizontal bar.
        AddShape(middleBar);

        MyRectangle bottomBar = new MyRectangle(Color.Purple, x, y + 90, 50, 10); //Bottom horizontal bar.
        AddShape(bottomBar);
    }

    public void ScaleDownAllShapes() //Scale down all shapes.
    {
        foreach (Shape s in _shapes)
        {
            s.ScaleDown();
        }
    }

    public void Save(string filename)
    {
        StreamWriter writer = new StreamWriter(filename);
        try
        {
            writer.WriteColor(_background);
            writer.WriteLine(_shapes.Count);
            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving drawing: " + ex.Message);
        }
        finally
        {
            writer.Close();
        }
    }

    public void Load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        try
        {
            _background = reader.ReadColor();
            int count = reader.ReadInteger();
            _shapes.Clear();
            for (int i = 0; i < count; i++)
            {
                Shape s;
                string kind = reader.ReadLine();
                switch (kind)
                {
                    case "Circle":
                        s = new MyCircle();
                        break;
                    case "Rectangle":
                        s = new MyRectangle();
                        break;
                    case "Line":
                        s = new MyLine();
                        break;
                    case "Ellipse":
                        s = new MyEllipse();
                        break;
                    default:
                        throw new InvalidDataException("Unknown shape type");
                }
                s.LoadFrom(reader);
                AddShape(s);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading the file" + ex.Message);
        }
        finally
        {
            reader.Close();
        }
    }
}   