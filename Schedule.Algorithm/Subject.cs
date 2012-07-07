using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Algorithm
{
    public class Subject
    {
        public string Name { get; set; }
        public SubjectType Type { get; set; }
        public Professor Professor { get; set; }
        public Subject(string aName, SubjectType aType, Professor aProfessor)
        {
            Name = aName;
            Type = aType;
            Professor = aProfessor;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
