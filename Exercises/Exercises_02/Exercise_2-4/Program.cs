class Sum
{
    public static void Main()
    {
        Sum sum = new Sum();
        sum.start();
    }

    private void start()
    {
        Console.WriteLine("sum()");
        Console.WriteLine(sum());
        Console.WriteLine("sum(7)");
        Console.WriteLine(sum(7));
        Console.WriteLine("sum(9, 11)");
        Console.WriteLine(sum(9, 11));
        Console.WriteLine("sum(1, 2, 3, 4, 5)");
        Console.WriteLine(sum(1, 2, 3, 4, 5));
        Console.WriteLine("sum(\"ab\", \"cdef\")");
        Console.WriteLine(sum("ab", "cdef"));
    }

    private int sum (params int[] values)
    {
        return values.Sum();
    }

    private int sum(int value0, int value1)
    {
        return -1;
    }

    private int sum(string value0, string value1)
    {
        return value0.Length + value1.Length;
    }
}