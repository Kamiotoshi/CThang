using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }
        public double AverageScore { get; private set; }
        public string AcademicPerformance { get; private set; }

        public Student(int id, string name, string gender, int age, double mathScore, double physicsScore, double chemistryScore)
        {
            Id = id;
            Name = name;
            Gender = gender;
            Age = age;
            MathScore = mathScore;
            PhysicsScore = physicsScore;
            ChemistryScore = chemistryScore;
            CalculateAverageScore();
            DetermineAcademicPerformance();
        }

        public void CalculateAverageScore()
        {
            AverageScore = (MathScore + PhysicsScore + ChemistryScore) / 3;
        }

        public void DetermineAcademicPerformance()
        {
            if (AverageScore >= 8.0)
            {
                AcademicPerformance = "Gioi";
            }
            else if (AverageScore >= 6.5)
            {
                AcademicPerformance = "Kha";
            }
            else if (AverageScore >= 5.0)
            {
                AcademicPerformance = "Trung binh";
            }
            else
            {
                AcademicPerformance = "Yeu";
            }
        }
    }
}
