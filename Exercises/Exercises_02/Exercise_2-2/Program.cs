public class program
{
    private enum Question
    {
        question,
        answer1,
        answer2,
        answer3,
        answer4,
        correctAnswer
    }

    private static Dictionary<Question, string>[] questions =
    {
        getQuestion("Whats the answer?", "1", "90", "42", "3", "3"),
        getQuestion("2^10", "1024" , "128" , "2048" , "512" , "1"),
        getQuestion("Whats the atomic number of helium?", "1" , "2" , "3" , "4" , "2"),
        getQuestion("Ice Tea Lemon or Peach?", "Lemon", "Peach", "I like both", "I don't like Ice Tea", "2"),
        getQuestion("Whats Elon Musks sons name?", "Jeff", "AE-μ MXVII", "Juan", "X AE A-XII", "4"),
        getQuestion("Where does Harry Potter Live?", "4 Pivet Drive", "Bahnhofstrasse 9", "221b bakers street", "Bella Mira 1", "1"),
        getQuestion("Who directed Avatar", "Christopher Nolan", "James Cameron", "Tim Burton", "Zack Snyder", "2"),
        getQuestion("What's Super Marios Surname", "Mario", "Luigi", "Figini", "Mussolini", "1"),
        getQuestion("Pi", "3.1415926", "3.1428571", "3.1414213", "69", "1"),
        getQuestion("Who played Batman in 1989", "Christian Bale", "Ben Affleck", "Robert Pattinson", "Michael Keaton", "4"),
    };
    private static string[] validAnswers = { "1", "2", "3", "4" };

    private static Random random = new Random();

    private const string line = "-----------------------------------------------";
    private const string correctAnswerMessage = "correct";
    private const string inCorrectAnswerMessage = "incorrect";
    private const string continueMessage = "Press [Enter] to continue";
    private const string replayMessage = "Press [Enter] to play again";
    private const string gameLengthMessage = "How many rounds do you wanna play (1-10)";
    private const string askUserMessage = "Choose wisely: ";

    private static readonly ConsoleColor colorBefore = Console.ForegroundColor; 

    public static void Main()
    {
        while (true)
        {
            int correctAnswers = 0;

            List<Dictionary<Question, string>> questionList = new List<Dictionary<Question, string>>(questions);

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
                randomNumber = random.Next(questionList.Count);

                Dictionary<Question, string> question = questionList[randomNumber];

                questionList.RemoveAt(randomNumber);

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine(line);
                    Console.WriteLine($"{question[Question.question]}:");
                    Console.WriteLine(line);
                    Console.WriteLine($"1. {question[Question.answer1]}");
                    Console.WriteLine($"2. {question[Question.answer2]}");
                    Console.WriteLine($"3. {question[Question.answer3]}");
                    Console.WriteLine($"4. {question[Question.answer4]}");
                    Console.Write(askUserMessage);
                    string answer = Console.ReadLine();

                    if (validAnswers.Contains(answer))
                    {
                        if(answer == question[Question.correctAnswer])
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(correctAnswerMessage);
                            Console.ForegroundColor = colorBefore;
                            correctAnswers++;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(inCorrectAnswerMessage);
                            Console.ForegroundColor = colorBefore;
                        }

                        Console.WriteLine(continueMessage);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    }
                }
            }
            Console.WriteLine($"You had {correctAnswers} out of {rounds} correct");
            Console.ForegroundColor= ConsoleColor.Green;
            Console.Write(String.Concat(Enumerable.Repeat("█", (int)(25*((double)correctAnswers/rounds)))));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Concat(Enumerable.Repeat("█", (int)(25*((double)(rounds-correctAnswers)/rounds)))));
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine($"{correctAnswers * 100 / rounds}%");
            Console.WriteLine();
            Console.ForegroundColor = colorBefore;

            Console.WriteLine(replayMessage);
            Console.ReadLine();
            Console.Clear();

        }
    }

    private static Dictionary<program.Question, string> getQuestion (string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer)
    {
        return new Dictionary<Question, string> {
            {Question.question, question},
            {Question.answer1, answer1 },
            {Question.answer2, answer2 },
            {Question.answer3, answer3 },
            {Question.answer4, answer4 },
            {Question.correctAnswer, correctAnswer },
        };
    }
}