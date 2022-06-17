public class program
{
    public static void Main ()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Point p1 = new()
        {
            X = 1,
            Y = 1
        };
        Point p2 = new()
        {
            X = 7,
            Y = 3
        };
        Point p3 = new()
        {
            X = 7,
            Y = 3
        };

        Console.WriteLine ($"U = {Geometry.perimeterTriangle (p1, p2, p3)}");
        Geometry.printTriangle(p1, p2, p3);

        Console.WriteLine ();
        p3.X = 4;

        Console.WriteLine($"U = {Geometry.perimeterTriangle(p1, p2, p3)}");
        Geometry.printTriangle(p1, p2, p3);
    }
}

public static class Geometry
{
    private static double distance (Point point1, Point point2)
    {
        double xDistance = point1.X - point2.X;
        double yDistance = point1.Y - point2.Y;

        double result = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        return result;
    }

    public static double perimeterTriangle(Point point1, Point point2, Point point3)
    {
        return distance(point1, point2) + distance(point1, point3) + distance(point2, point3);
    }

    public static void printTriangle(Point point1, Point point2, Point point3)
    {
        List<Point> points = new(){ point1, point2, point3 };

        Point? pointLeft = null;
        double minDistance = 0;
        foreach(Point point in points )
        {
            double distanceToZero = distance(point, new Point() { X = 0, Y = 0 });
            if(distanceToZero < minDistance || pointLeft == null)
            {
                pointLeft = point;
                minDistance = distanceToZero;
            }
        }

        points.Remove(pointLeft);

        Point? pointRight = null;
        minDistance = 0;
        foreach(Point point in points)
        {
            double distanceToY = point.Y;
            if (distanceToY < minDistance || pointRight == null)
            {
                pointRight = point;
                minDistance = distanceToY;
            }
        }

        points.Remove(pointRight);

        Point pointTop = points[0];

        Console.WriteLine($"    {pointTop.X}/{pointTop.Y}");
        Console.WriteLine($"    ╱╲");
        Console.WriteLine($"   ╱  ╲");
        Console.WriteLine($"  ╱    ╲");
        Console.WriteLine($" ╱______╲");
        Console.WriteLine($"{pointLeft.X}/{pointLeft.Y}   {pointRight.X}/{pointRight.Y}");
    }
}

public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
}