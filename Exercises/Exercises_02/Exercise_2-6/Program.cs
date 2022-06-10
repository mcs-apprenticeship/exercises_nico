class PerfectNumbers
{
    public static void Main ()
    {
        PerfectNumbers perfectNumbers = new PerfectNumbers();
        perfectNumbers.start ();
    }

    private void start()
    {
        int[] perfectNumbers = getPerfectNumbers(4);

        foreach(int num in perfectNumbers)
        {
            Console.WriteLine(num);
        }
    }

    private int[] getPerfectNumbers(int amount)
    {
        int[] perfectNumbers = new int[amount];
        
        int j = 2;
        for(int i = 0; i < amount; i++)
        {
            while(j != getAllDivisors(j).Sum())
            {
                j++;
            }
            perfectNumbers[i] = j++;
        }
        return perfectNumbers;
    }

    private int[] getAllDivisors (int num)
    {
        List<int> divisors = new List<int> ();
        for(int i = 1; i < num; i++)
        {
            if(num % i == 0)
            {
                divisors.Add(i);
            }
        }
        return divisors.ToArray ();
    }
}