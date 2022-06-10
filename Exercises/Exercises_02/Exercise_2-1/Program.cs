public class program
{
    private const string errorMessage = "Ungültige Eingabe";
    private const string continueMessage = "Press [Enter] to continue";
    private const string line = "-----------------------------------------------";
    private const string question = "type a Number between 1 and 7: ";
            
    private static readonly int[] allowedNumbers = { 1, 2, 3, 4, 5, 6, 7 };

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine(line);
            Console.Write(question);
            string input = Console.ReadKey().KeyChar.ToString();
            Console.WriteLine();
            if(int.TryParse(input, out int num))
            {
                Console.WriteLine(weekDays(num));
                Console.WriteLine(continueMessage);
            }
            else
            {
                Console.WriteLine(errorMessage);
                Console.WriteLine(continueMessage);
            }
            Console.ReadLine();
            Console.Clear();
        }
    }

    private static bool isValid(string stringToValidate, out int num)
    {
        if(int.TryParse(stringToValidate, out num))
        {

            return allowedNumbers.Contains(num);
        }
        return false;
    }

    private static string weekDays(int day)
    {
        return day switch
        {
            1 => "Monday",
            2 => "Tuesday",
            3 => "Wednesday",
            4 => "Thursday",
            5 => "Friday",
            6 => "Saturday",
            7 => "Sunday",
            _ => errorMessage
        };
    }
}