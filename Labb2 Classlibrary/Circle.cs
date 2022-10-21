using System.Numerics;

namespace Labb2_Classlibrary
{
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
        public override float Circumference => radius * 2 * MathF.PI;
        public override float Area => (radius * radius) * MathF.PI;

        public override string ToString()
        {
            return $"--- circle --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1})\n" +
                $"Circumference : {Circumference:F1}\n" +
                $"Area : {Area:F1}\n";
        }
    }
}