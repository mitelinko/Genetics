using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Algorithm
{
    public class Room
    {
        public string Name { get; set; }
        public SubjectType Type { get; set; }
        public Room(string aName, SubjectType aType)
        {
            Name = aName;
            Type = aType;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
