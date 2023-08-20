namespace SRM.Api.Entites
{
    public class Grade : EntityBase
    {
        public float Point { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
