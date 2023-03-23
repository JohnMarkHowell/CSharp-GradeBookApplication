using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) 
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (this.Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            }

            var sortedStudents = this.Students.OrderByDescending(x => x.AverageGrade).ToList();

            int segsize = Convert.ToInt32(Math.Floor(sortedStudents.Count() / 5d));

            // this will hold the resulting letter grade index
            int letterIndex = 1;

            int segindex = 0;

            foreach (var student in sortedStudents)
            {
                if (averageGrade >= student.AverageGrade)
                {
                    break;
                }
                else
                {
                    segindex++;
                    if (segindex >= segsize)
                    {
                        letterIndex++;
                        segindex = 0;
                    }
                }
            }

            char letterGrade = default;

            switch (letterIndex)
            {
                case 0:
                case 1:
                    letterGrade = 'A';
                    break;
                case 2:
                    letterGrade = 'B';
                    break;
                case 3:
                    letterGrade = 'C';
                    break;
                case 4:
                    letterGrade = 'D';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }

            return letterGrade;
        }

        public override void CalculateStatistics()
        {
            if (this.Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (this.Students.Count() < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }
    }
}
