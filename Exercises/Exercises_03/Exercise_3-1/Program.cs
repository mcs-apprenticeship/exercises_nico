public class program
{
    public static void Main ()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Point p1 = new()
        {
            x = 1,
            y = 1
        };
        Point p2 = new()
        {
            x = 7,
            y = 3
        };
        Point p3 = new()
        {
            x = 7,
            y = 3
        };

        Console.WriteLine ($"A = {Geometry.perimeterTriangle (p1, p2, p3)}");
        Geometry.printTriangle(p1, p2, p3);

        Console.WriteLine ();
        p3.x = 4;

        Console.WriteLine(Geometry.perimeterTriangle(p1, p2, p3));
        Geometry.printTriangle(p1, p2, p3);
    }
}

public static class Geometry
{
    private static double distance (Point point1, Point point2)
    {
        double xDistance = point1.x - point2.x;
        double yDistance = point1.y - point2.y;

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
            double distanceToZero = distance(point, new Point() { x = 0, y = 0 });
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
            double distanceToY = point.y;
            if (distanceToY < minDistance || pointRight == null)
            {
                pointRight = point;
                minDistance = distanceToY;
            }
        }

        points.Remove(pointRight);

        Point pointTop = points[0];

        Console.WriteLine($"    {pointTop.x}/{pointTop.y}");
        Console.WriteLine($"    ╱╲");
        Console.WriteLine($"   ╱  ╲");
        Console.WriteLine($"  ╱    ╲");
        Console.WriteLine($" ╱______╲");
        Console.WriteLine($"{pointLeft.x}/{pointLeft.y}   {pointRight.x}/{pointRight.y}");
    }
}

public class Point
{
    public int x;
    public int y;
}