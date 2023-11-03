namespace WEBSITE101.Relationship
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Classroom Classroom { get; set; }
        public List<Student> Students { get; set; }
        public Course Course { get; set; }
    }
}
