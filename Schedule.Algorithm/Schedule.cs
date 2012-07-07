using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Schedule.Algorithm
{
    public struct Schedule
    {
        private int dayCount;
        private int classPerDayCount;
        private Activity[] activities;
        public float Fitness{get;set;}
        Random rand;
        public Schedule(int aDayCount, int aClassPerDayCount):this()
        {
            
            dayCount = aDayCount;
            classPerDayCount = aClassPerDayCount;
            activities = new Activity[dayCount * classPerDayCount * Configuration.Instance.Rooms.Count];
            for (int i = 0; i < activities.Length; i++)
            {
                activities[i] = Activity.Empty;
            }
            rand = new Random();
        }
        static public Schedule CreateRandom(int aDayCount, int aClassPerDayCount)
        {
            Schedule temp = new Schedule(aDayCount, aClassPerDayCount);
            temp.InitializeActivities();
            return temp;
        }
        private void InitializeActivities()
        {
            foreach (StudentGroup group in Configuration.Instance.Groups)
            {
                foreach (var keyvalue in group.SubjectCounts)
                {
                    AddActivities(group, keyvalue.Key, keyvalue.Value);
                }
            }
            
        }
        private void AddActivities(StudentGroup group, Subject subject, short count)
        {
            rand = new Random(DateTime.Now.Millisecond);
            while (count > 0)
            {
                int ind = rand.Next(0, activities.Length);
                if (activities[ind].IsEmpty)
                {
                    activities[ind] = new Activity(subject, group);
                    count--;
                }
                else
                {
                    continue;
                }
            }
        }
        public void Mutation(float mutationChance)
        {
            if (rand.Next(1000) > mutationChance * 1000) return;
            int act1 = rand.Next(0 ,activities.Length);
            Activity temp = activities[act1];
            int act2 = rand.Next(0, activities.Length);
            activities[act1] = activities[act2];
            activities[act2] = temp;
        }
        public Schedule Crossover(Schedule aSchedule, float crossoverChance)
        {
            if (rand.Next(1000) > crossoverChance * 1000) return aSchedule;
            int ind = rand.Next(0, activities.Length);
            Schedule child = new Schedule(dayCount, classPerDayCount);

            for (int i = 0; i < ind; i++)
            {
                child.activities[i] = activities[i];
            }

            for (int i=ind; i<child.activities.Length; i++)
            {
                child.activities[i] = aSchedule.activities[i];
            }

            return child;
        }
        public float EvaluateFitness()
        {
            int maxOverlappingProfessors = 0;
            int maxOverlappingGroups = 0;
            int overlappingProfessors = 0;
            int overlappingGroups = 0;
            var professorsInHour = new HashSet<Professor>();
            var groupsInHour = new HashSet<StudentGroup>();
            int roomCount = Configuration.Instance.Rooms.Count;
            for (int hour = 0; hour < activities.Length; hour += roomCount)
            {
                professorsInHour.Clear();
                groupsInHour.Clear();
                for (int room = hour; room < hour + roomCount; room++)
                {
                    if (activities[room].IsEmpty) continue;
                    if(professorsInHour.Contains(activities[room].Subject.Professor))
                        overlappingProfessors++;
                    else
                        professorsInHour.Add(activities[room].Subject.Professor);

                    if (groupsInHour.Contains(activities[room].Group))
                        overlappingGroups++;
                    else
                        groupsInHour.Add(activities[room].Group);

                    maxOverlappingGroups++;
                    maxOverlappingProfessors++;
                }
            }
            float professorFitness = ((float)maxOverlappingProfessors - (float)overlappingProfessors) / (float)maxOverlappingProfessors;
            float groupFitness = ((float)maxOverlappingGroups - (float)overlappingGroups) / (float)maxOverlappingGroups;
            double fitness = (0.5 * professorFitness) + (0.5 * groupFitness);
            Fitness = (float)fitness;
            return (float)fitness;
        }
    }
}
