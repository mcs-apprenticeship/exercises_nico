class Fibonacci
{
    public static void Main()
    {
        Fibonacci fibonacci = new Fibonacci();
        fibonacci.start();
    }

    private void start()
    {

        int input = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Max value");
            string inputString = Console.ReadLine();
            if(int.TryParse(inputString, out input)){
                break;
            }
        }
        Console.WriteLine("--------");
        
        Console.WriteLine(fibonacciRecursive(input));
    }

    private void fibonacciLoop (int max)
    {
        List<int> values = new List<int>();
        values.Add(1);
        int currentIndex = 0;
        while (true)
        {
            Console.WriteLine(values[currentIndex]);
            currentIndex = values.Count();
            int num0 = currentIndex - 2 >= 0 ? values[currentIndex - 2] : 0;
            int num1 = values[currentIndex - 1];
            values.Add(num0 + num1);
            if (values[currentIndex] > max)
            {
                return;
            }
        }
    }


    private string fibonacciRecursive(int max, List<int>? values = null)
    {
        if(values == null)
        {
            values = new List<int>();
            values.Add(1);
            Console.WriteLine(1);
        }

        int currentIndex = values.Count();
        int num0 = currentIndex - 2 >= 0 ? values[currentIndex - 2] : 0;
        int num1 = values[currentIndex - 1];
        values.Add(num0 + num1);
        if (values[currentIndex] <= max)
        {
            return values[currentIndex] + "\n" + fibonacciRecursive(max, values);
        }
        return String.Empty;
    }
}