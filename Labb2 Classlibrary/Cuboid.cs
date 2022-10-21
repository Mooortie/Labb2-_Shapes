using System.Numerics;

namespace Labb2_Classlibrary
{
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


        public override float Area => 2 *((size.X * size.Z) + (size.Z * size.Y) + (size.X * size.Y));

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
}