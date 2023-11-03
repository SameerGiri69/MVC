namespace WEBSITE101.Relationship
{
    public class Student
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Course>? Courses { get; set; } 
        public Classroom? classroom { get; set; } 
        public List<Teacher>? Teachers { get; set; }  
    }
}
