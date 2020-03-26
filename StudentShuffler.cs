using System;   
using System.Collections.Generic;
using System.Linq;

namespace Student_Shuffle
{
    class StudentShuffler
    {
        private Config _config;

        public StudentShuffler(Config config)
        {
            _config = config;
        }

        public List<List<Student>> GetRandomizedGroups()
        {
            List<Student> students = GetStudents();
            List<List<Student>> groups = new List<List<Student>>();
            int studentsRemainder;
            int studentsPerGroupCount = Math.DivRem(students.Count, _config.GroupsNumber, out studentsRemainder);
            
            for (int i = 0; i < _config.GroupsNumber; i++)
            {
                List<Student> shuffledGroup = students.Take(studentsPerGroupCount).ToList();
                groups.Add(shuffledGroup);
                students = students.Skip(studentsPerGroupCount).ToList();
                
            }
            // If there are students remaining, put each of them in a group until there is no more
            for (int i = 0; i < studentsRemainder; i++)
            {
                groups[i].Add(students[i]);
               
            }
            return groups;
        }

        public List<Student> GetStudents()
        {
            IEnumerable<Student> students = _config.Students;
            Random randomGenerator = new Random();
            int chosenStudentIndex;
            int studentsNumber = students.Count();

            List<Student> shuffledStudents = students.ToList();
            for (int i = 0; i < studentsNumber; i++)
            {
                chosenStudentIndex = randomGenerator.Next(i, studentsNumber);
                var chosenStudent = shuffledStudents[chosenStudentIndex];
                shuffledStudents[chosenStudentIndex] = shuffledStudents[i];
                shuffledStudents.RemoveAt(i);
                shuffledStudents.Insert(0, chosenStudent);
            }

            return shuffledStudents;
        }
    }
}
