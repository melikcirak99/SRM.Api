namespace SRM.Api.Entites
{
    public class Lesson : EntityBase
    {
        public string Name { get; set; }
        public ICollection<StudentLesson> StudentLessons { get; set; }
        public ICollection<Grade> Grades { get; set; }

    }
}
