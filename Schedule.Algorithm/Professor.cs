﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Algorithm
{
    public class Professor
    {
        public string Name { get; set; }
        public Professor(string aName)
        {
            Name = aName;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
