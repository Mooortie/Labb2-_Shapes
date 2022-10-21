using System.Numerics;

namespace Labb2_Classlibrary
{
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
}