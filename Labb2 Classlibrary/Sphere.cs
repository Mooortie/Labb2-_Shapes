using System.Numerics;

namespace Labb2_Classlibrary
{
    public class Sphere : Shape3D
    {
        public Sphere(Vector3 _center, float _radius)
        {
            center = _center;
            radius = _radius;
        }

        private Vector3 center;
        private readonly float radius;

        public override float Volume => (4 * MathF.PI * radius * radius * radius) / 3;

        public override Vector3 Center => center;
        public override float Area => 4 * MathF.PI * (radius * radius);

        public override string ToString()
        {
            return $"--- Sphere --- \n" +
                $"Center : ({Center.X:F1} {Center.Y:F1} {Center.Z:F1})\n" +
                $"Volume : {Volume:F1}\n" +
                $"Area :{Area:F1}\n";
        }
    }
}