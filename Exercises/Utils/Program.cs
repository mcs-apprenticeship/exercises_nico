namespace Exercises_03
{
    public class Program { public static void Main () { } }

    public class UserInput
    {
        UiUtils uiUtils;

        public UserInput(int width)
        {
            uiUtils = new UiUtils(width);
        }

        public int GetInt(Func<int, bool> validator)
        {
            string numAsString = string.Empty;

            uiUtils.StartLine(": ", UiUtils.BorderType.Bottom);
            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey();
                if (int.TryParse(input.KeyChar.ToString(), out _))
                {
                    numAsString += input.KeyChar;
                }
                else if (input.Key == ConsoleKey.Enter)
                {
                    if (numAsString.Length > 0)
                    {
                        int num = int.Parse(numAsString);
                        if (validator(num))
                        {
                            return num;
                        }
                    }
                    numAsString = String.Empty;
                    uiUtils.StartLine(": ", UiUtils.BorderType.Bottom);
                }
                else
                {
                    if (input.Key == ConsoleKey.Backspace)
                    {
                        numAsString = numAsString.Remove(numAsString.Length - 1);
                    }
                    uiUtils.ClearCurrentConsoleLine();
                    uiUtils.StartLine($": {numAsString}", UiUtils.BorderType.Bottom);
                }
            }
        }

        public int choose(Func<object?> printBefore, params string[] choices)
        {
            int input = 0;
            while (input > choices.Length || input < 1)
            {
                Console.Clear();
                printBefore();

                for (int i = 1; i <= choices.Length; i++)
                {
                    uiUtils.PrintLine($" {i}: {choices[i - 1]}");
                }


                uiUtils.PrintBorder(UiUtils.BorderType.Light);
                uiUtils.StartLine(": ", UiUtils.BorderType.Bottom);
                string inputString = Console.ReadLine();
                int.TryParse(inputString, out input);
            }
            return input;
        }
    }

    public class UiUtils
    {
        public enum BorderType
        {
            Light,
            Bold,
            Top,
            Bottom,
        }

        private int width;

        public UiUtils(int width)
        {
            this.width = width;
        }

        public void PrintHeader(string name)
        {
            Console.Clear();
            PrintBorder(BorderType.Top);
            PrintLine(name);
            PrintBorder(BorderType.Bold);
        }

        public void PrintLine(string content, ConsoleColor color = ConsoleColor.White)
        {
            ConsoleColor colorBefore = Console.ForegroundColor;
            Console.Write("┃");
            Console.ForegroundColor = color;
            Console.Write($"{content}{String.Concat(Enumerable.Repeat(" ", (width - content.Length)))}");
            Console.ForegroundColor = colorBefore;
            Console.WriteLine("┃");
        }

        public void StartLine(string content, BorderType borderAfter)
        {
            PrintLine(content);
            PrintBorder(borderAfter);
            Console.SetCursorPosition(content.Length + 1, Console.CursorTop - 2);

        }

        public void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public void PrintBorder(BorderType bt)
        {
            switch (bt)
            {
                case BorderType.Light:
                    PrintBorder('┠', '─', '┨');
                    break;
                case BorderType.Bold:
                    PrintBorder('┣', '━', '┫');
                    break;
                case BorderType.Top:
                    PrintBorder('┏', '━', '┓');
                    break;
                case BorderType.Bottom:
                    PrintBorder('┗', '━', '┛');
                    break;
            }
        }
        private void PrintBorder(char first, char border, char last)
        {
            Console.WriteLine($"{first}{String.Concat(Enumerable.Repeat(border, width))}{last}");
        }
    }
}