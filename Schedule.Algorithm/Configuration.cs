using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Algorithm
{
    public class Configuration
    {
        static private Configuration configuration;
        static public Configuration Instance
        {
            get
            {
                if (configuration == null)
                    configuration = new Configuration();
                return configuration;
            }
        }

        private Configuration()
        {
            LoadDefaultValues();
        }

        private void LoadDefaultValues()
        {
            Rooms = new List<Room> 
            { 
                new Room("21", SubjectType.Ordinary), //5
                new Room("42", SubjectType.Ordinary),
                new Room("32", SubjectType.ComputerLab),
                new Room("37", SubjectType.ComputerLab),
                new Room("13", SubjectType.Ordinary) 
            };
            /*
            List<Room> newRooms = new List<Room>
            {
                new Room("11", SubjectType.Ordinary),
                new Room("13", SubjectType.Ordinary),
                new Room("14", SubjectType.Ordinary),
                new Room("15", SubjectType.Ordinary),
                new Room("16", SubjectType.Ordinary),
                new Room("17", SubjectType.Ordinary),
                new Room("21", SubjectType.Ordinary),
                new Room("25", SubjectType.ComputerLab),
                new Room("26", SubjectType.ComputerLab),
                new Room("27", SubjectType.Ordinary),
                new Room("31", SubjectType.ComputerLab),
                new Room("34", SubjectType.ComputerLab),
                new Room("35", SubjectType.ComputerLab),
                new Room("36", SubjectType.ComputerLab),
                new Room("37", SubjectType.ComputerLab),
                new Room("41", SubjectType.Ordinary),
                new Room("42", SubjectType.Ordinary),
                new Room("43", SubjectType.Ordinary),
                new Room("44", SubjectType.Ordinary),
                new Room("45", SubjectType.Ordinary),
                new Room("46", SubjectType.Ordinary),
                new Room("47", SubjectType.Ordinary)
            };
            */
            Professors = new List<Professor>
            {
                new Professor("Abramovich"),//8
                new Professor("Mitova"),
                new Professor("Chorbadjiev"),
                new Professor("Mitov"),
                new Professor("Frenski"),
                new Professor("Taneva"),
                new Professor("Ivanov"),
                new Professor("Kirov")
            };

            Subjects = new List<Subject>
            {
                new Subject("Maths",SubjectType.Ordinary,Professors.Find(p=>p.Name=="Abramovich")),
                new Subject("Bel",SubjectType.Ordinary,Professors.Find(p=>p.Name=="Mitova")),
                new Subject("OOP",SubjectType.ComputerLab,Professors.Find(p=>p.Name=="Chorbadjiev")),
                new Subject("OS",SubjectType.ComputerLab,Professors.Find(p=>p.Name=="Chorbadjiev")),
                new Subject("TP",SubjectType.ComputerLab,Professors.Find(p=>p.Name=="Mitov")),
                new Subject("History",SubjectType.Ordinary,Professors.Find(p=>p.Name=="Frenski")),
                new Subject("Arh",SubjectType.ComputerLab,Professors.Find(p=>p.Name=="Taneva")),
                new Subject("ET",SubjectType.Ordinary,Professors.Find(p=>p.Name=="Ivanov")),
                new Subject("AE",SubjectType.Ordinary,Professors.Find(p=>p.Name=="Kirov"))
            };

            Groups = new List<StudentGroup>
            {
                new StudentGroup("11A"),
                new StudentGroup("11B"),
                new StudentGroup("11V"),
                new StudentGroup("11G")
            };

            var d = Groups.Find(g => g.Name == "11A").SubjectCounts;
            d.Add(Subjects.Find(s => s.Name == "Maths"), 4);
            d.Add(Subjects.Find(s => s.Name == "Bel"), 4);
            d.Add(Subjects.Find(s => s.Name == "OOP"), 2);
            d.Add(Subjects.Find(s => s.Name == "OS"), 3);
            d.Add(Subjects.Find(s => s.Name == "TP"), 4);
            d.Add(Subjects.Find(s => s.Name == "History"), 2);
            d.Add(Subjects.Find(s => s.Name == "Arh"), 2);
            d.Add(Subjects.Find(s => s.Name == "ET"), 2);
            d.Add(Subjects.Find(s => s.Name == "AE"), 3);

            d = Groups.Find(g => g.Name == "11B").SubjectCounts;
            d.Add(Subjects.Find(s => s.Name == "Maths"), 4);
            d.Add(Subjects.Find(s => s.Name == "Bel"), 4);
            d.Add(Subjects.Find(s => s.Name == "OOP"), 2);
            d.Add(Subjects.Find(s => s.Name == "OS"), 3);
            d.Add(Subjects.Find(s => s.Name == "TP"), 4);
            d.Add(Subjects.Find(s => s.Name == "History"), 2);
            d.Add(Subjects.Find(s => s.Name == "Arh"), 2);
            d.Add(Subjects.Find(s => s.Name == "ET"), 2);
            d.Add(Subjects.Find(s => s.Name == "AE"), 3);

            d = Groups.Find(g => g.Name == "11V").SubjectCounts;
            d.Add(Subjects.Find(s => s.Name == "Maths"), 4);
            d.Add(Subjects.Find(s => s.Name == "Bel"), 4);
            d.Add(Subjects.Find(s => s.Name == "OOP"), 2);
            d.Add(Subjects.Find(s => s.Name == "OS"), 3);
            d.Add(Subjects.Find(s => s.Name == "TP"), 4);
            d.Add(Subjects.Find(s => s.Name == "History"), 2);
            d.Add(Subjects.Find(s => s.Name == "Arh"), 2);
            d.Add(Subjects.Find(s => s.Name == "ET"), 2);
            d.Add(Subjects.Find(s => s.Name == "AE"), 3);

            d = Groups.Find(g => g.Name == "11G").SubjectCounts;
            d.Add(Subjects.Find(s => s.Name == "Maths"), 4);
            d.Add(Subjects.Find(s => s.Name == "Bel"), 4);
            d.Add(Subjects.Find(s => s.Name == "OOP"), 2);
            d.Add(Subjects.Find(s => s.Name == "OS"), 3);
            d.Add(Subjects.Find(s => s.Name == "TP"), 4);
            d.Add(Subjects.Find(s => s.Name == "History"), 2);
            d.Add(Subjects.Find(s => s.Name == "Arh"), 2);
            d.Add(Subjects.Find(s => s.Name == "ET"), 2);
            d.Add(Subjects.Find(s => s.Name == "AE"), 3);
        }

        public List<Room> Rooms { get; set; }
        public List<Professor> Professors { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<StudentGroup> Groups { get; set; }
    }
}
