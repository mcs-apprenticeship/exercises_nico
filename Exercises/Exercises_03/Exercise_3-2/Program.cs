namespace Exercises_03{
    class Program
    {
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
                int input = UserInput.choose(PrintHead, "reset date", "reset time", "reload");
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
                UiUtils.PrintLine("In deadline!", ConsoleColor.Green);
            }
            else
            {
                UiUtils.PrintLine("Not in deadline!", ConsoleColor.Red);
            }
        }

        private static object? PrintHead()
        {
            UiUtils.PrintHeader();
            UiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            UiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            PrintInDeadline();
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            return null;
        }

        private static void SetTime()
        {
            dl.ResetTime();
            UiUtils.PrintHeader();
            UiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            UiUtils.PrintLine($"Time:");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            UiUtils.PrintLine("Hours?");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            int h = UserInput.GetInt(IsValidHour);
            dl.SetHour(h);
            Console.Clear();
            UiUtils.PrintHeader();
            UiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            UiUtils.PrintLine($"Time: {GetHours()}");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            UiUtils.PrintLine("Minutes?");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            int m = UserInput.GetInt(IsValidMin);
            dl.SetMin(m);
            Console.Clear();
            UiUtils.PrintHeader();
            UiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}/{GetDays()}");
            UiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            UiUtils.PrintLine("Seconds?");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            int s = UserInput.GetInt(IsValidSec);
            dl.SetSec(s);
        }

        private static void SetDate()
        {
            UiUtils.PrintHeader();
            UiUtils.PrintLine("Date:");
            if (dlSet) UiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            UiUtils.PrintLine("Date year?");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            int year = UserInput.GetInt(IsValidYear);
            dl.SetYear(year);
            Console.Clear();
            UiUtils.PrintHeader();
            UiUtils.PrintLine($"Date: {GetYears()}");
            if (dlSet) UiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            UiUtils.PrintLine("Date Month?");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            int month = UserInput.GetInt(IsValidMonth);
            dl.SetMonth(month);
            Console.Clear();
            UiUtils.PrintHeader();
            UiUtils.PrintLine($"Date: {GetYears()}/{GetMonths()}");
            if (dlSet) UiUtils.PrintLine($"Time: {GetHours()}:{GetMins()}:{GetSecs()}");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            UiUtils.PrintLine("Date Day?");
            UiUtils.PrintBorder(UiUtils.BorderType.Light);
            int day = UserInput.GetInt(IsValidDay);
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
