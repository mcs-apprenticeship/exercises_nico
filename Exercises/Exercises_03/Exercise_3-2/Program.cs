namespace Exercises_03{
    class Program
    {
        private static UiUtils uiUtils = new UiUtils(40);
        private static UserInput userInput = new UserInput(40);

        private static Deadline dl = new(
            new DateTime(),
            new Duration()
        );

        private static bool dlSet = false;

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                if (!dlSet)
                {
                    SetDate();
                    SetTime();
                    dlSet = true;
                }

                PrintHead();
                int input = userInput.choose(PrintHead, "reset date", "reset time", "reload");
                int i = input;
                switch (input)
                {
                    case 1:
                        SetDate();
                        break;
                    case 2:
                        SetTime();
                        break;
                }
            }
        }

        private static string GetWithZeros(int num, int digits)
        {
            int amount = digits - num.ToString().Length;
            return String.Concat(Enumerable.Repeat("0", amount)) + num;
        }

        private static string GetHours()
        {
            return GetWithZeros((int)Math.Floor(dl.duration.GetDuration(Duration.Units.h)), 2);
        }

        private static string GetMins()
        {
            return GetWithZeros((int)(Math.Floor(dl.duration.GetDuration(Duration.Units.m) - Math.Floor(dl.duration.GetDuration(Duration.Units.h)) * 60)), 2);
        }

        private static string GetSecs()
        {
            return GetWithZeros((int)(Math.Floor(dl.duration.GetDuration(Duration.Units.s) - Math.Floor(dl.duration.GetDuration(Duration.Units.m)) * 60)), 2);
        }

        private static string GetYears()
        {
            return GetWithZeros(dl.start.Year, 4);
        }

        private static string GetMonths()
        {
            return GetWithZeros(dl.start.Month, 2);
        }

        private static string GetDays()
        {
            return GetWithZeros(dl.start.Day, 2);
        }

        private static void PrintInDeadline()
        {
            if (dl.InDeadline())
            {
                uiUtils.PrintLine("In deadline!", ConsoleColor.Green);
            }
            else
            {
                uiUtils.PrintLine("Not in deadline!", ConsoleColor.Red);
            }
        }

        private static object? PrintHead()
        {
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            uiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            PrintInDeadline();
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            return null;
        }

        private static void SetTime()
        {
            dl.ResetTime();
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            uiUtils.PrintLine($"Time:");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            uiUtils.PrintLine("Hours?");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            int h = userInput.GetInt(IsValidHour);
            dl.SetHour(h);
            Console.Clear();
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            uiUtils.PrintLine($"Time: {GetHours()}");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            uiUtils.PrintLine("Minutes?");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            int m = userInput.GetInt(IsValidMin);
            dl.SetMin(m);
            Console.Clear();
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            uiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            uiUtils.PrintLine("Seconds?");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            int s = userInput.GetInt(IsValidSec);
            dl.SetSec(s);
        }

        private static void SetDate()
        {
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine("Date:");
            if (dlSet) uiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            uiUtils.PrintLine("Date year?");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            int year = userInput.GetInt(IsValidYear);
            dl.SetYear(year);
            Console.Clear();
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine($"Date: {GetYears()}");
            if (dlSet) uiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            uiUtils.PrintLine("Date Month?");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            int month = userInput.GetInt(IsValidMonth);
            dl.SetMonth(month);
            Console.Clear();
            uiUtils.PrintHeader("Deadline");
            uiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}");
            if (dlSet) uiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            uiUtils.PrintLine("Date Day?");
            uiUtils.PrintBorder(UiUtils.BorderType.Light);
            int day = userInput.GetInt(IsValidDay);
            dl.SetDay(day);
        }

        private static bool IsValidYear(int year)
        {
            return year > 0 && year < 10000;
        }

        private static bool IsValidMonth(int month)
        {
            if(month > 0 && month <= 12)
            {
                return true;
            }
            return false;
        }

        private static bool IsValidDay(int day)
        {
            if (day > 0 && day <= 31)
            {
                return true;
            }
            return false;
        }

        private static bool IsValidHour(int h)
        {
            if (h >= 0 && h < 24)
            {
                return true;
            }
            return false;
        }

        private static bool IsValidMin(int m)
        {
            if (m >= 0 && m < 60)
            {
                return true;
            }
            return false;
        }

        private static bool IsValidSec(int s)
        {
            if (s >= 0 && s < 60)
            {
                return true;
            }
            return false;
        }
    }

    

    class Deadline
    {
        public DateTime start { get; private set; }
        public Duration duration { get; private set; }

        public Deadline(DateTime start, Duration duration)
        {
            this.start = start;
            this.duration = duration;
        }

        public void ResetTime()
        {
            duration = new Duration();
        }

        public void SetYear(int year)
        {
            start = new DateTime(year, start.Month, start.Day);
        }

        public void SetMonth(int month)
        {
            start = new DateTime(start.Year, month, start.Day);
        }

        public void SetDay(int day)
        {
            start = new DateTime(start.Year, start.Month, day);
        }

        public void SetHour(int h)
        {
            duration.AddSeconds(h * 3600);
        }

        public void SetMin(int m)
        {
            duration.AddSeconds(m * 60);
        }

        public void SetSec(int s)
        {
            duration.AddSeconds(s);
        }

        public Boolean InDeadline()
        {
            return start.AddSeconds(duration.GetDuration(Duration.Units.s)) > DateTime.Now;
        }
    }

    class Duration
    {
        public enum Units
        {
            s,
            m,
            h
        }

        private int durationS;

        public double GetDuration(Units chosenUnit)
        {
            return chosenUnit switch
            {
                Units.s => durationS,
                Units.m => (double)durationS / 60,
                Units.h => (double)durationS / 3600,
                _ => 0,
            };
        }
        public void SetDuration(double amount,Units chosenUnit)
        {
            durationS = chosenUnit switch
            {
                Units.s => (int)amount,
                Units.m => (int)(amount * 60),
                Units.h => (int)(amount * 3600),
                _ => throw new NotImplementedException()
            };
        }

        public void AddSeconds (int amount)
        {
            durationS += amount;
        }
    }
}
