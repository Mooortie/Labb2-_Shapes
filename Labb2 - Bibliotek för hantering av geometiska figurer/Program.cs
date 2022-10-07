using Labb2_Classlibrary;
using System.Numerics;
List<Shape> shapeList = new() { };
int num = 1;
float totalArea = 0;
float totalCircumference = 0;
Shape3D currentHighestVolume = null;


Console.Write("Assign a centerpoint for both x and y and z \nAssign X: ");
Vector3 assignedVector;

assignedVector.X = float.Parse(Console.ReadLine());
Console.Write("Assign Y: ");
assignedVector.Y = float.Parse(Console.ReadLine());
Console.Write("Assign Z: ");
assignedVector.Z = float.Parse(Console.ReadLine());
Console.Clear();

for (int i = 0; i < 20; i++)
{
    //uncomment the one u want to run. 

    Shape? shape = Shape.GenerateShape(assignedVector); 
    //Shape? shape = Shape.GenerateShape();
    if (shape is not null)
    {
        shapeList.Add(shape);
    }
}
foreach (var shape in shapeList)
{
    totalArea += shape.Area;
    Console.WriteLine($"{num++} : {shape}");
    if (shape is Shape3D)
    {
        if (currentHighestVolume == null || ((Shape3D)shape).Volume > currentHighestVolume.Volume)
        {
            currentHighestVolume = ((Shape3D)shape);
        }
    }
    if (shape is Triangle)
    {
        totalCircumference += ((Triangle)shape).Circumference;
    }
}

var shapeCounts =
    from shape in shapeList
    group shape by shape.GetType().Name into shapeGroup  //Interet is power https://www.csharp-examples.net/linq-count/
    select new 
    {
        shapeName = shapeGroup.Key,
        count = shapeGroup.Count(),
    };
shapeCounts = shapeCounts.OrderByDescending(x => x.count);
Console.WriteLine($"The most amount of shapes is : {shapeCounts.First().shapeName} = {shapeCounts.First().count}");

Console.WriteLine($"The total circumference of all triangles is : {totalCircumference:F1}");
Console.WriteLine($"The average area of all shapes is : {totalArea / 20:F1}");
Console.WriteLine($"Largest volume is \n{currentHighestVolume}");

