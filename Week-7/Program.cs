using System;
using System.Drawing;
using ShapeDrawer;
using SplashKitSDK;

namespace Week_7
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line,
            Ellipse
        }

        public static void Main()
        {
            Window shapesWindows;
            shapesWindows = new Window("Dave Nguyen, 104697710", 700, 700);
            ShapeKind shapeToAdd = ShapeKind.Rectangle;
            Drawing myDrawing = new Drawing();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    shapeToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    shapeToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    shapeToAdd = ShapeKind.Line;
                }

                if (SplashKit.KeyTyped(KeyCode.EKey))
                {
                    shapeToAdd = ShapeKind.Ellipse;
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape newShape;
                    switch (shapeToAdd)
                    {
                        case ShapeKind.Rectangle:
                            newShape = new MyRectangle();
                            newShape.Color = SplashKitSDK.Color.Cyan;
                            break;
                        case ShapeKind.Circle:
                            newShape = new MyCircle();
                            break;
                        case ShapeKind.Line:
                            newShape = new MyLine(); 
                            break;
                        case ShapeKind.Ellipse:
                            newShape = new MyEllipse();
                            break;
                        default:
                            newShape = new MyRectangle();
                            break;
                    }
                    Point2D currentPosition = SplashKit.MousePosition();
                    Console.WriteLine(currentPosition.X);
                    newShape.X = (float)currentPosition.X;
                    newShape.Y = (float)currentPosition.Y;
                    myDrawing.AddShape(newShape);
                    Console.WriteLine(myDrawing.ShapeCount);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectedShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomColor();
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.RemoveLastShape();
                }

                if (SplashKit.KeyTyped(KeyCode.DeleteKey))
                {
                    foreach (Shape s in myDrawing.SelectedShapes)
                    {
                        if (s.Selected == true)
                        {
                            myDrawing.RemoveShape(s);
                            break;
                        }
                    }
                }

                if (SplashKit.KeyTyped(KeyCode.GKey)) //Generate Random Shapes.
                {
                    myDrawing.GenerateRandomShapes();
                }

                if (SplashKit.KeyTyped(KeyCode.QKey)) //Randomize Colors of all shapes.
                {
                    myDrawing.RandomizeAllColors();
                }

                if (SplashKit.KeyTyped(KeyCode.DKey)) //Draw my first name DAVE.
                {
                    myDrawing.DrawDAVE();
                }

                if (SplashKit.KeyTyped(KeyCode.MKey)) //Scale down all shapes.
                {
                    myDrawing.ScaleDownAllShapes();
                }

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("MyDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("MyDrawing.txt");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error loading drawing: " + e.Message);
                    }
                }
                myDrawing.Draw();
                SplashKit.RefreshScreen();
            }
            while (!shapesWindows.CloseRequested);
        }
    }
}