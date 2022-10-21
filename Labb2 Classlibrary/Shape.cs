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
}