namespace Exercises_03
{
    public class Program
    {
        private const int width = 60;

        private static readonly UiUtils uiUtils = new(width);
        private static readonly UserInput userInput= new(width);

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            uiUtils.PrintHeader("Animalpedia");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.DarkGreen;

            object? print()
            {
                uiUtils.PrintHeader("Animalpedia");
                uiUtils.PrintLine("Choose one of our MANY animals");
                uiUtils.PrintBorder(UiUtils.BorderType.Light);
                return null;
            }

            ILifeform[] lifeforms =
            {
                new Dog(),
                new Cat(),
                new Egli(),
                new Frog(),
                new Human()
            };

            string[] options = new string[lifeforms.Length + 1];
            for (int i = 0; i < lifeforms.Length; i++)
            {
                options[i] = lifeforms[i].Name;
            }
            options[options.Length - 1] = "Exit";

            while (true)
            {
                int input = userInput.choose(print, options);

                switch (input)
                {
                    case 1:
                        DisplayLifeform(new Dog());
                        break;
                    case 2:
                        DisplayLifeform(new Cat());
                        break;
                    case 3:
                        DisplayLifeform(new Egli());
                        break;
                    case 4:
                        DisplayLifeform(new Frog());
                        break;
                    case 5:
                        DisplayLifeform(new Human());
                        break;
                    case 6:
                        return;
                }

            }
        }

        public static void DisplayLifeform(ILifeform lifeform)
        {
            while (true)
            {
                Console.Clear();
                uiUtils.PrintHeader("Animalpedia");
                uiUtils.PrintLine(" <- [B]");
                uiUtils.PrintBorder(UiUtils.BorderType.Light);
                uiUtils.PrintLine($"Name: {lifeform.Name}");
                uiUtils.PrintLine($"Type: {lifeform.Type}");
                uiUtils.PrintLine($"Sound: {lifeform.Sound}");
                uiUtils.PrintBorder(UiUtils.BorderType.Light);
                foreach(string line in lifeform.Img)
                {
                    uiUtils.PrintLine(line);
                }
                uiUtils.PrintBorder(UiUtils.BorderType.Bottom);
                var input = Console.ReadKey().Key;
                if(input == ConsoleKey.B)
                {
                    break;
                }
            }
        }
    }

    public interface ILifeform
    {
        public string Name { get; }
        public string Type { get; }
        public string Sound { get; }
        public string[] Img { get; }
    }

    public class Dog : ILifeform
    {
        public string Name { get; } = "Dog";
        public string Type { get; } = "Mammal";
        public string Sound { get; } = "bark";
        public string[] Img { get; } =
        {
            "   / \\__",
            "  (    @\\___",
            "  /         O",
            " /   (_____/",
            "/_____/   U"
        };
    }

    public class Cat : ILifeform
    {
        public string Name { get; } = "Cat";
        public string Type { get; } = "Mammal";
        public string Sound { get; } = "meow";
        public string[] Img { get; } =
        {
            "    /\\_____/\\",
            "   /  o   o  \\",
            "  ( ==  ^  == )",
            "   )         (",
            "  (           )",
            " ( (  )   (  ) )",
            "(__(__)___(__)__)"
        };
    }

    public class Egli : ILifeform
    {
        public string Name { get; } = "Egli";
        public string Type { get; } = "Fish";
        public string Sound { get; } = "blub";
        public string[] Img { get; } =
        {
            "|\\   \\\\__     o",
            "| \\_/    o \\    o",
            "> _   (( <_  oo",
            "| / \\__+___/",
            "|/     |/"
        };
    }

    public class Frog : ILifeform
    {
        public string Name { get; } = "Frog";
        public string Type { get; } = "Amphibian";
        public string Sound { get; } = "quak";
        public string[] Img { get; } = 
        {
            "       _     _",
            "      (')-=-(')",
            "    __(   \"\"   )__",
            "   / _/'-----'\\_ \\",
            "___\\ \\     // //___",
            ">____)/_\\---/_\\(____<"
        };
    }

    public class Human : ILifeform
    {
        public string Name { get; } = "Human";
        public string Type { get; } = "Mammal";
        public string Sound { get; } = "talk";
        public string[] Img { get; } =
        {
            "   .-'~\" -.",
            "  / `-    \\ ",
            " />  `.  -.| ",
            "/_     '-.__) ",
            " |-  _.' \\ | ",
            " `~~;     \\\\ ",
            "    /      \\\\)",
            "   '.___.-'`\""
        };
    }
}