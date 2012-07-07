using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Algorithm
{
    public class StudentGroup
    {
        public string Name { get; set; }
        public Dictionary<Subject, short> SubjectCounts { get; set; }

        public StudentGroup(string aName)
        {
            Name = aName;
            SubjectCounts = new Dictionary<Subject, short>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
