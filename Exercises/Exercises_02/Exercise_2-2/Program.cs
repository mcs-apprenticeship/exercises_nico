public class program
{
    private static Dictionary<string, string>[] questions =
    {
        new Dictionary<string, string> {
            {"question", "Whats the answer?"},
            {"1", "1" },
            {"2", "90" },
            {"3", "42" },
            {"4", "3" },
            {"correctId", "3" },
        },
        new Dictionary<string, string> {
            {"question", "2^10"},
            {"1", "1024" },
            {"2", "128" },
            {"3", "2048" },
            {"4", "512" },
            {"correctId", "1" },
        },
        new Dictionary<string, string> {
            {"question", "Whats the atomic number of helium"},
            {"1", "1" },
            {"2", "2" },
            {"3", "3" },
            {"4", "4" },
            {"correctId", "2" },
        },
        new Dictionary<string, string> {
            {"question", "Ice Tea Lemon or Peach?"},
            {"1", "Lemon" },
            {"2", "Peach" },
            {"3", "I like both" },
            {"4", "I don't like Ice Tea" },
            {"correctId", "2" },
        },
        new Dictionary<string, string> {
            {"question", "Whats Elon Musks sons name"},
            {"1", "Jeff" },
            {"2", "AE-μ MXVII" },
            {"3", "Juan"},
            {"4", "X AE A-XII" },
            {"correctId", "4" },
        },
        new Dictionary<string, string> {
            {"question", "Where does Harry Potter Live"},
            {"1", "4 Pivet Drive" },
            {"2", "Bahnhofstrasse 9" },
            {"3", "221b bakers street"},
            {"4", "Bella Mira 1" },
            {"correctId", "1" },
        },
        new Dictionary<string, string>
        {
            {"question", "Who directed Avatar"},
            {"1", "Christopher Nolan" },
            {"2", "James Cameron" },
            {"3", "Tim Burton"},
            {"4", "Zack Snyder" },
            {"correctId", "2" },
        },
        new Dictionary<string, string>
        {
            {"question", "What's Super Marios Surname"},
            {"1", "Mario" },
            {"2", "Luigi" },
            {"3", "Figini"},
            {"4", "Mussolini" },
            {"correctId", "1" },
        },
        new Dictionary<string, string>
        {
            {"question", "Pi"},
            {"1", "3.1415926" },
            {"2", "3.1428571" },
            {"3", "3.1414213"},
            {"4", "69" },
            {"correctId", "1" },
        },
        new Dictionary<string, string>
        {
            {"question", "Who played Batman in 1989"},
            {"1", "Christian Bale" },
            {"2", "Ben Affleck" },
            {"3", "Robert Pattinson"},
            {"4", "Michael Keaton" },
            {"correctId", "4" },
        },
    };
    private static string[] validAnswers = { "1", "2", "3", "4" };

    private static Random random = new Random();

    private const string line = "-----------------------------------------------";
    private const string correctAnswerMessage = "correct";
    private const string inCorrectAnswerMessage = "incorrect";
    private const string invalidAnswerMessage = "incorrect";
    private const string continueMessage = "Press [Enter] to continue";
    private const string replayMessage = "Press [Enter] to play again";
    private const string gameLengthMessage = "How many rounds do you wanna play (1-10)";
    private const string askUserMessage = "Choose wisely: ";

    private static readonly ConsoleColor colorBefore = Console.ForegroundColor; 

    public static void Main()
    {
        while (true)
        {
            List<int> askedQuestions = new List<int>();

            int randomNumber = 0;

            int rounds = 0;
            while(!(1 <= rounds && rounds <= 10)){
                Console.WriteLine(gameLengthMessage);
                string input = Console.ReadLine();
                int.TryParse(input, out rounds);
                Console.Clear();
            }

            for (int i = 0; i < rounds; i++)
            {
                while(true)
                {
                    randomNumber = random.Next(questions.Length);
                    if (!askedQuestions.Contains(randomNumber))
                    {
                        break;
                    }
                }
                askedQuestions.Add(randomNumber);

                Dictionary<string, string> question = questions[randomNumber];

                while (true)
                {
                    Console.WriteLine(line);
                    Console.WriteLine($"{question["question"]}:");
                    Console.WriteLine(line);
                    Console.WriteLine($"1. {question["1"]}");
                    Console.WriteLine($"2. {question["2"]}");
                    Console.WriteLine($"3. {question["3"]}");
                    Console.WriteLine($"4. {question["4"]}");
                    Console.Write(askUserMessage);
                    string answer = Console.ReadLine();

                    if (validAnswers.Contains(answer))
                    {
                        if(answer == question["correctId"])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(correctAnswerMessage);
                            Console.ForegroundColor = colorBefore;

                            Console.WriteLine(continueMessage);
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(inCorrectAnswerMessage);
                        Console.ForegroundColor = colorBefore;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(invalidAnswerMessage);
                        Console.ForegroundColor = colorBefore;
                    }

                    Console.WriteLine(continueMessage);
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            Console.WriteLine(replayMessage);
            Console.ReadLine();
            Console.Clear();

        }
    }
}