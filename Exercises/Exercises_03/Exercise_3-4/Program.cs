namespace Exercises_03
{
    class Program
    {

    }

    public interface IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public Genders Gender { get; }
        public string Address { get; }
    }

    public class Student : IPerson
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Genders Gender { get; private set; }
        public string Address { get; private set; }
        public int StudentNum { get; private set; }
        public string University { get; private set; }
        public List<string> Courses { get; private set; }

        public Student(string name, int age, Genders gender, string address, int studentNum, string university, List<string> courses)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
            StudentNum = studentNum;
            University = university;
            Courses = courses;
        }
    }

    public class Visitor : IPerson
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Genders Gender { get; private set; }
        public string Address { get; private set; }

        public Visitor(string name, int age, Genders gender, string address)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
        }
    }

    public class Lecturer : IPerson
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Genders Gender { get; private set; }
        public string Address { get; private set; }
        public string University { get; private set; }
        public double Salary { get; private set; }

        public Lecturer(string name, int age, Genders gender, string address, string university, double salary)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Address = address;
            University = university;
            Salary = salary;
        }
    }

    public enum Genders
    {
        m,
        w,
        x
    }
}