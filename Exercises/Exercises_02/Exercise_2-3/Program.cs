class UnitConverter
{
    public static void Main()
    {
        UnitConverter uc = new UnitConverter();
        uc.start();
    }

    private void start()
    {
        while (true)
        {
            int userChoice = choose("mm <--> inch", "°C <--> °F", "km <--> Miles");
            switch (userChoice)
            {
                case 1:
                    convertUi("mm", "inch", 1/25.4);
                    break;
                case 2:
                    convertUi("°C", "°F", (double)9/5, 32);
                    break;
                case 3:
                    convertUi("km", "Miles", 0.6214);
                    break;
            }
        }
    }

    private void convertUi ( string unit0, string unit1, double multiplicator, double numToAdd = 0)
    {
        //direction: true = unit0 --> unit1, false = unit1 --> unit0
        bool direction = true;

        int convertedValue = 0;
        while (true)
        {
            Console.Clear();
            printHeader();
            printLine("[Q] Exit - [F1] Switch Units");
            printLine('=');

            if (direction)
            {
                printLine($" {unit0} --> {unit1}");
            }
            else
            {
                printLine($" {unit1} --> {unit0}");
            }
            printLine('-');

            if(readNumShortcut( out ConsoleKey shortCut, out double num, ConsoleKey.F1, ConsoleKey.Q))
            {
                switch (shortCut)
                {
                    case ConsoleKey.F1:
                        convertedValue = 0;
                        direction = !direction;
                        break;
                    case ConsoleKey.Q:
                        return;
                }
            }
            else
            {
                Console.WriteLine();
                printLine('-');
                printLine($" {(direction ? (num * multiplicator) + numToAdd: (num - numToAdd) / multiplicator)}");
                printLine('=');
                Console.ReadKey();
            }

        }

    }

    public static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }

    private bool readNumShortcut ( out ConsoleKey shortCut, out double num, params ConsoleKey[] Shortcuts)
    {
        string numAsString = string.Empty;
        
        startLine(" ");
        while (true)
        {
            ConsoleKeyInfo input = Console.ReadKey();
            if (Shortcuts.Contains(input.Key))
            {
                num = 0;
                shortCut = input.Key;
                return true;
            }
            else if (int.TryParse(input.KeyChar.ToString(), out _) || input.KeyChar == '.')
            {
                numAsString += input.KeyChar;
            }
            else if( input.Key == ConsoleKey.Enter)
            {
                num = double.Parse(numAsString);
                shortCut = new ConsoleKey();
                return false;
            }
            else
            {
                ClearCurrentConsoleLine();
                startLine($" {numAsString}");
            }
        }
    }

    private void printHeader ()
    {
        printLine('=');
        printLine("Unit Converter");
        printLine('=');
    }

    private void printLine (string content)
    {
        Console.WriteLine($"¦{content}{String.Concat(Enumerable.Repeat(" ", (55 - content.Length)))}¦");
    }

    private void printLine (char filler)
    {
        Console.WriteLine($"¦{String.Concat(Enumerable.Repeat(filler, (55)))}¦");
    }

    private void startLine(string content)
    {
        printLine(content);
        Console.SetCursorPosition(content.Length + 1, Console.CursorTop - 1);

    }

    private int choose ( params string[] choices)
    {
        int input = 0;
        while(input > choices.Length || input < 1)
        {
            Console.Clear();
            printHeader();

            int i = 0;
            foreach( string choice in choices)
            {
                i++;
                printLine($" {i}: {choice}");
            }

            printLine('-');
            startLine(": ");
            string inputString = Console.ReadLine();
            int.TryParse(inputString, out input);
        }
        return input;
    }


}