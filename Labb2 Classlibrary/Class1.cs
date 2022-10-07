using System.Numerics;

namespace Labb2_Classlibrary 
{ 
    public abstract class Shape 
    {
        enum Shapes 
        {
            Circle, 
            Rectangle,
            Square,
            Triangle,
            Cuboid,
            Cube,
            Sphere,
        }
        
        public abstract Vector3 Center { get; }
        public abstract float Area { get; }
        public static Shape? GenerateShape(Vector3 centerPoint)
        {
            Random rnd = new();
            Shapes shape = (Shapes)rnd.Next(Enum.GetNames(typeof(Shapes)).Length);
            return shape switch
            {
                Shapes.Circle => new Circle(new Vector2(centerPoint.X,centerPoint.Y), rnd.Next(1, 15)),
                Shapes.Rectangle => new Rectangle(new Vector2(centerPoint.X,centerPoint.Y), new Vector2(rnd.Next(1, 15), rnd.Next(1, 15))),
                Shapes.Square => new Rectangle(new Vector2(centerPoint.X, centerPoint.Y), rnd.Next(1, 15)),
                Shapes.Triangle => new Triangle(new Vector2(rnd.Next(1, 15), rnd.Next(1, 15)), new Vector2(rnd.Next(1, 15), rnd.Next(1, 15)), new Vector3(centerPoint.X, centerPoint.Y,0.4f)),
                Shapes.Cuboid => new Cuboid(new Vector3(centerPoint.X, centerPoint.Y,centerPoint.Z), new Vector3(rnd.Next(1, 15), rnd.Next(1, 15), rnd.Next(1, 15))),
                Shapes.Cube => new Cuboid(new Vector3(centerPoint.X, centerPoint.Y, centerPoint.Z), rnd.Next(1, 15)),
                Shapes.Sphere => new Sphere(new Vector3(centerPoint.X, centerPoint.Y, centerPoint.Z), rnd.Next(1, 15)),
                _ => null,
            };
        }

        public static Shape? GenerateShape()
        {
            Random rnd = new();
            Shapes shape = (Shapes)rnd.Next(Enum.GetNames(typeof(Shapes)).Length);
            return shape switch
            {
                Shapes.Circle => new Circle(new Vector2(rnd.Next(1, 15), rnd.Next(1, 15)), rnd.Next(1, 15)),
                Shapes.Rectangle => new Rectangle(new Vector2(rnd.Next(1, 15), rnd.Next(1, 15)), new Vector2(rnd.Next(1, 15), rnd.Next(1, 15))),
                Shapes.Square => new Rectangle(new Vector2(rnd.Next(1, 15)), rnd.Next(1, 15)),
                Shapes.Triangle => new Triangle(new Vector2(rnd.Next(1, 15), rnd.Next(1, 15)), new Vector2(rnd.Next(1, 15), rnd.Next(1, 15)), new Vector2(rnd.Next(1, 15), rnd.Next(1, 15))),
                Shapes.Cuboid => new Cuboid(new Vector3(rnd.Next(1, 15), rnd.Next(1, 15), rnd.Next(1, 15)), new Vector3(rnd.Next(1, 15), rnd.Next(1, 15), rnd.Next(1, 15))),
                Shapes.Cube => new Cuboid(new Vector3(rnd.Next(1, 15), rnd.Next(1, 15), rnd.Next(1, 15)), rnd.Next(1, 15)),
                Shapes.Sphere => new Sphere(new Vector3(rnd.Next(1, 15), rnd.Next(1, 15), rnd.Next(1, 15)), rnd.Next(1, 15)),
                _ => null,
            };
        }
    }
    public abstract class Shape2D : Shape
    {
        public abstract float Circumference
        {
            get;
        }
    }
    public abstract class Shape3D : Shape
    {
        public abstract float Volume
        {
            get;
        }
    }

    //Inheritance of Shape2D

    public class Circle : Shape2D
    {

        public Circle(Vector2 _center, float _radius)
        {
            center = _center;
            radius = _radius;
        }

        private Vector2 center;
        private readonly float radius;
        public override Vector3 Center => new(center, 0.0f);
        public override float Circumference => radius * 2 * 3.14f;
        public override float Area => (radius * radius) * 3.14f;

        public override string ToString()
        {
            return $"--- circle --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1})\n" +
                $"Circumference : {Circumference:F1}\n" +
                $"Area : {Area:F1}\n";
        }
    }
    public class Rectangle : Shape2D
    {
        public Rectangle(Vector2 _center, Vector2 _size)
        {
            center = _center;
            size = _size;
        }

        public Rectangle(Vector2 center, float width)
        {
            this.center = center;
            size = new Vector2(width, width);
        }

        public bool IsSquare => size.Y == size.X;

        private Vector2 center;
        private Vector2 size;
        public override float Circumference => size.X * 2 + size.Y * 2;

        public override Vector3 Center => new(center, 0.0f);

        public override float Area => size.X * size.Y;

        public override string ToString()
        {
            return $"--- {(IsSquare ? "Square" : "Rectangle")} --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1})\n" +
                $"Width : {size.X:F1}\n" +
                $"Height : {size.Y:F1}\n" +
                $"Circumference : {Circumference:F1}\n" +
                $"Area : {Area:F1}\n";
        }
    }
    public class Triangle : Shape2D
    {
        public Triangle(Vector2 p1, Vector2 p2, Vector2 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = p3;
        }
        public Triangle(Vector2 p1, Vector2 p2, Vector3 p3)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.p3 = CalculateFromCenter(p3);
        }

        private Vector2 p1;
        private Vector2 p2;
        private Vector2 p3;

        public override float Circumference
        {
            get
            {
                float lineOne = (p2 - p1).Length();
                float lineTwo = (p3 - p1).Length();
                float lineThree = (p3 - p2).Length();

                return lineOne + lineTwo + lineThree;
            }
        }
        public override float Area
        {
            get
            {
                float lineOne = (p2 - p1).Length();
                float lineTwo = (p3 - p1).Length();
                float lineThree = (p3 - p2).Length();

                float semiPerimiter = (lineOne + lineTwo + lineThree) / 2;

                return (float)Math.Sqrt(semiPerimiter * (semiPerimiter - lineOne) * (semiPerimiter - lineTwo) * (semiPerimiter - lineThree));
            }
        }
        public override Vector3 Center => CalculateTriangleCenter();

        private Vector3 CalculateTriangleCenter()
        {
            float midX = (p1.X + p2.X + p3.X) / 3;
            float midY = (p1.Y + p2.Y + p3.Y) / 3;
            return new Vector3(midX, midY, 0.0f);
        }

        private Vector2 CalculateFromCenter(Vector3 Center)
        {
            Vector3 newP3 = (Center * 3);
            newP3.X = newP3.X - p2.X - p1.X;
            newP3.Y = newP3.Y - p2.Y - p1.Y;

            return new Vector2(newP3.X, newP3.Y);
        }
        public override string ToString()
        {
            return $"--- Triangle --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1})\n" +
                $"Corners : ({p1.X:F1} {p1.Y:F1}) ({p2.X:F1} {p2.Y:F1}) ({p3.X:F1} {p3.Y:F1})\n" +
                $"Circumference : {Circumference:F1}\n" +
                $"Area : {Area:F1}\n";
        }
    }

    //Inheritance of Shape3D

    public class Cuboid : Shape3D
    {
        public Cuboid(Vector3 _center, Vector3 _size)
        {
            center = _center;
            size = _size;
        }
        public Cuboid(Vector3 center, float width)
        {
            this.center = center;
            size = new Vector3(width, width, width);
        }
        private Vector3 center;
        private Vector3 size;

        public bool IsCube => size.Y == size.X && size.Y == size.Z;
        public override float Volume => size.Y * size.X * size.Z;
        public override Vector3 Center => center;

        public override float Area => (size.Y * size.X) * 6;

        public override string ToString()
        {
            return $"--- {(IsCube ? "Cube" : "Cuboid")} --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1} {Center.Z:F1})\n" +
                $"Width : {size.X:F1}\n" +
                $"Height : {size.Y:F1}\n" +
                $"Depth: {size.Z:F1}\n" +
                $"Volume : {Volume:F1}\n" +
                $"Area : {Area:F1}\n";
        }
    }
    public class Sphere : Shape3D
    {
        public Sphere(Vector3 _center, float _radius)
        {
            center = _center;
            radius = _radius;
        }

        private Vector3 center;
        private readonly float radius;

        public override float Volume => (4 * 3.14f * radius * radius * radius) / 3;

        public override Vector3 Center => center;
        public override float Area => 4 * 3.14f * (radius * radius);

        public override string ToString()
        {
            return $"--- Sphere --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1} {Center.Z:F1})\n" +
                $"Volume : {Volume:F1}\n" +
                $"Area :{Area:F1}\n";
        }
    }
}