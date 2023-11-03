using WEBSITE101.Relationship;

namespace WEBSITE101.Relationship
{
    public class Classroom
    {
        public int Id { get; set; }             
        public int Capacity { get; set; }

        public List<Student> Students { get; set; } 
        public Teacher Teacher { get; set; }

        public Course Course { get; set; }

    }
}
