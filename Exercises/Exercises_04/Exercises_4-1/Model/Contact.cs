using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_4_1
{
    internal class Contact
    {
        public string AvatarPath { get; set; }
        public Gender Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsMarried { get; set; }
        public double Weight { get; set; }

        public string FullName { get
            {
                return $"{FirstName} {LastName}";
            } 
        }

        public bool IsMale { get => Gender == Gender.m; }
        public bool IsFemale { get => Gender == Gender.f; }
        public bool IsOther { get => Gender == Gender.x; }
    }

    internal enum Gender
    {
        m,
        f,
        x
    }
}
