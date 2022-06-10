const int width = 55;

start();

void start()
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
                convertUi("°C", "°F", 9.0/5, 32);
                break;
            case 3:
                convertUi("km", "Miles", 0.6214);
                break;
        }
    }
}

void convertUi ( string unit0, string unit1, double multiplicator, double numToAdd = 0)
{
    //direction: true = unit0 --> unit1, false = unit1 --> unit0
    bool direction = true;

    int convertedValue = 0;
    while (true)
    {
        Console.Clear();
        printHeader();
        printLine("[Q] Exit - [F1] Switch Units");
        printBorderLine('=');

        if (direction)
        {
            printLine($" {unit0} --> {unit1}");
        }
        else
        {
            printLine($" {unit1} --> {unit0}");
        }
        printBorderLine('-');

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
            printBorderLine('-');
            printLine($" {(direction ? (num * multiplicator) + numToAdd: (num - numToAdd) / multiplicator)}");
            printBorderLine('=');
            Console.ReadKey();
        }

    }

}

void ClearCurrentConsoleLine()
{
    int currentLineCursor = Console.CursorTop;
    Console.SetCursorPosition(0, Console.CursorTop);
    Console.Write(new string(' ', Console.WindowWidth));
    Console.SetCursorPosition(0, currentLineCursor);
}

bool readNumShortcut ( out ConsoleKey shortCut, out double num, params ConsoleKey[] Shortcuts)
{
    // only one dot

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
            if( input.Key == ConsoleKey.Backspace)
            {
                numAsString = numAsString.Remove(numAsString.Length - 1);
            }
            ClearCurrentConsoleLine();
            startLine($" {numAsString}");
        }
    }
}

void printHeader ()
{
    printBorderLine('=');
    printLine("Unit Converter");
    printBorderLine('=');
}

void printLine (string content)
{
    //55 const

    Console.WriteLine($"¦{content}{String.Concat(Enumerable.Repeat(" ", (width - content.Length)))}¦");
}

void printBorderLine (char filler)
{
    Console.WriteLine($"¦{String.Concat(Enumerable.Repeat(filler, width))}¦");
}

void startLine(string content)
{
    printLine(content);
    Console.SetCursorPosition(content.Length + 1, Console.CursorTop - 1);

}

int choose ( params string[] choices)
{
    int input = 0;
    while(input > choices.Length || input < 1)
    {
        Console.Clear();
        printHeader();

        for(int i= 0; i < choices.Length; i++)
        {
            printLine($" {i}: {choices[i]}");
        }


        printBorderLine('-');
        startLine(": ");
        string inputString = Console.ReadLine();
        int.TryParse(inputString, out input);
    }
    return input;
}