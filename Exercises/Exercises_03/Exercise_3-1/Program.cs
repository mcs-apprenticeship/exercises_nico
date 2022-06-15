public class program
{
    public static void Main ()
    {
        point p1 = new()
        {
            x = 1,
            y = 1
        };
        point p2 = new()
        {
            x = 7,
            y = 3
        };
        point p3 = new()
        {
            x = 7,
            y = 3
        };

        Console.WriteLine (Geometry.perimeterTriangle (p1, p2, p3));

        p3.x = 4;

        Console.WriteLine(Geometry.perimeterTriangle(p1, p2, p3));
    }
}

public static class Geometry
{
    private static double distance (point point1, point point2)
    {
        double xDistance = point1.x - point2.x;
        double yDistance = point1.y - point2.y;

        double result = Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        return result;
    }

    public static double perimeterTriangle(point point1, point point2, point point3)
    {
        return distance(point1, point2) + distance(point1, point3) + distance(point2, point3);
    }
}

public class point
{
    public int x;
    public int y;
}