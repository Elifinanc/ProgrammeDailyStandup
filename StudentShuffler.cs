using System;   
using System.Collections.Generic;
using System.Linq;

namespace Student_Shuffle
{
    class StudentShuffler
    {
        private IReadable Readable { get; set; }

        public StudentShuffler(IReadable readable)
        {
            Readable = readable;
        }

        public List<List<string>> GetRandomizedGroups(int numberOfGroup)
        {
            List<String> students = GetStudents();
            List<List<string>> groups = new List<List<string>>();
            int studentsRemainder;
            int studentsPerGroupCount = Math.DivRem(students.Count, numberOfGroup, out studentsRemainder);
            string[] tail = new string[students.Count];
            students.CopyTo(tail);
            // Split the initial group in a given number of groups
            for (int i = 0; i < numberOfGroup; i++)
            {
                List<string> shuffledGroup = tail.Take(studentsPerGroupCount).ToList();
                groups.Add(shuffledGroup);
                tail = tail.Skip(studentsPerGroupCount).ToArray();
            }
            // If there are students remaining, put each of them in a group until there is no more
            for (int i = 0; i < studentsRemainder; i++)
            {
                List<string> groupWithOneRemainder = groups[i];
                groupWithOneRemainder.Add(tail[i]);
            }
            return groups;
        }

        public List<string> GetStudents()
        {
            IEnumerable<String> students = Readable.ExtractFileLines();
            Random randomGenerator = new Random();
            int chosenStudentIndex;
            int studentsNumber = students.Count();

            List<String> shuffledStudents = students.ToList();
            for (int i = 0; i < studentsNumber; i++)
            {
                chosenStudentIndex = randomGenerator.Next(i, studentsNumber);
                String chosenStudent = shuffledStudents[chosenStudentIndex];
                shuffledStudents[chosenStudentIndex] = shuffledStudents[i];
                shuffledStudents.RemoveAt(i);
                shuffledStudents.Insert(0, chosenStudent);
            }

            return shuffledStudents;
        }
    }
}
