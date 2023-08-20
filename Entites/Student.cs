namespace SRM.Api.Entites
{
    public class Student : EntityBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public ICollection<StudentLesson> StudentLessons { get; set; }
        public ICollection<Grade> Grades { get; set; }

        public double CalculateRanking()
        {
            int totalLessonCount = StudentLessons.Select(x => x.LessonId).Distinct().Count();

            if (totalLessonCount == 0)
            {
                return 0.0;
            }
            // Dolu olan ders sayısı
            int filledLessonCount = Grades.Select(x=>x.LessonId).Distinct().Count();

            // Profil doluluk oranını hesapla
            double fillRate = (double)filledLessonCount / totalLessonCount * 100;

            return fillRate;
        }

    }
}
