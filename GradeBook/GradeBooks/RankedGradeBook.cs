using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook: BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted): base(name, isWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int studentCount = Students.Count;
            char letterGrade = 'F';
            if (studentCount < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                int higherGradeCount = Students.Where(s => s.AverageGrade >= averageGrade).Count();
                double percentile = (double)higherGradeCount / (double)studentCount;

                if (percentile <= 0.2d) letterGrade = 'A';
                if (percentile <= 0.4d && percentile > 0.2d) letterGrade = 'B';
                if (percentile <= 0.6d && percentile > 0.4d) letterGrade = 'C';
                if (percentile <= 0.8d && percentile > 0.6d) letterGrade = 'D';
            }
            return letterGrade;
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }
    }
}
