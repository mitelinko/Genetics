using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schedule.Algorithm
{
    public class Activity
    {
        public Subject Subject { get; set; }
        public int ID { get; set; }
        public StudentGroup Group { get; set; }
        private bool empty;
        static private int id = 0;
        private static Activity emptyActivity = new Activity(true);
        public static Activity Empty
        {
            get { return emptyActivity; }
        }
        public bool IsEmpty
        {
            get { return empty; }
        }
        private Activity() { }
        public Activity(Subject aSubject, StudentGroup aGroup)
        {
            empty = false;
            Subject = aSubject;
            Group = aGroup;
            ID = ++id;
        }
        private Activity(bool aEmpty)
        {
            empty = aEmpty;
            ID = -1;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Activity)) return false;
            var act = (Activity)obj;
            return act.ID == this.ID;
        }
        public bool Equals(Activity act)
        {
            return act.ID == this.ID;
        }
        public override int GetHashCode()
        {
            return ID;
        }
        public override string ToString()
        {
            return string.Format("{0} {1}", Subject, ID);
        }
        Activity MemberwiseClone()
        {
            return new Activity(this.Subject, this.Group);
        }

        
    }
}
