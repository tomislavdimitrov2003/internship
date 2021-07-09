namespace LinqExercise
{
    using System.Collections.Generic;
    using System.Linq;

    public class LinqExercise
    {
        public static void Main()
        {
            const string FilePath = @"../../Students-data.txt";

            List<Student> students = new List<Student>();
            string[] data = System.IO.File.ReadAllLines(FilePath);

            foreach (string line in data)
            {
                if (line[0] != 'I') 
                {
                    string[] tokens = line.Split();

                    int id = int.Parse(tokens[0]);
                    string firstName = tokens[1];
                    string lastName = tokens[2];
                    string email = tokens[3];
                    string gender = tokens[4];
                    string studentType = tokens[5];
                    int examResult = int.Parse(tokens[6]);
                    int homeworksSent = int.Parse(tokens[7]);
                    int homeworksEvaluated = int.Parse(tokens[8]);
                    double teamworkScore = double.Parse(tokens[9]);
                    int attendancesCount = int.Parse(tokens[10]);
                    double bonus = double.Parse(tokens[11]);

                    students.Add(new Student(
                        id,
                        firstName,
                        lastName,
                        email,
                        gender,
                        studentType,
                        examResult,
                        homeworksSent,
                        homeworksEvaluated,
                        teamworkScore,
                        attendancesCount,
                        bonus));

                }
            }

            //var studentWithExamResults = students.Where(student => student.ExamResult > 5);

            //var MaleStudents = from student in students
            //               where student.Gender == "Male"
            //               select student;
            //var StudentNameStartsWithA = from student in students
            //                             where student.FirstName.StartsWith("A")
            //               select student;
            //var OnlineStudentsOver350 = from student in students
            //               where student.StudentType == "Online" && student.ExamResult>=350
            //               select student;
            //var OrderedStudentsOver300 = from student in students
            //                             where student.StudentType == "Online" && student.ExamResult >= 300
            //                             orderby student.ExamResult descending
            //                             select student;
            //var OrderedStudentsWithoutHomework = from student in students
            //                             where student.HomeworksSent == 0
            //                             orderby student.FirstName
            //                             orderby student.LastName
            //                             select student;
            //var StudentEmails = students.Select(email => email.Email);
            //var StudentsOver5Attendances = from student in students
            //                               where student.AttendancesCount < 5
            //                               select student;
            //var StudentExamResultsAndAttendancesOver5 = StudentsOver5Attendances.Select(x => new { ExamResult = x.ExamResult, Attendances = x.AttendancesCount });
            //int StudentBonusOver4Count = (from student in students
            //                              where student.Bonus >= 4
            //                              select student).Count();
            ////var StudentBonusOver4Count = students.Count(student => student.Bonus >= 4);
            //var OnlineStudentExamAverage = (from student in students
            //                                where student.StudentType == "Online"
            //                                select student.ExamResult).Average();
            var groupStudentsByFirstLetter = from student in students
                                             group student by student.FirstName[0] into grouped
                                             select new { StudentsByFirstLetter = grouped };

            foreach (var item in groupStudentsByFirstLetter)
            {
                System.Console.WriteLine("1");
                System.Console.WriteLine($"{item.StudentsByFirstLetter.Key}");
                item.StudentsByFirstLetter.ToList().ForEach(x => System.Console.WriteLine($"{x.FirstName} {x.LastName}"));
            }

            int a = 5;
        }          
    }
}
