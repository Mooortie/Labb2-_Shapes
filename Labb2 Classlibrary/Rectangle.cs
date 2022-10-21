using System.Numerics;

namespace Labb2_Classlibrary
{
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
}