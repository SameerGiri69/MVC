namespace WEBSITE101.Relationship
{
    public class Course
    {
        public int Id { get; set; }  
        
        public string? Name { get; set; }
        public List<Student>? Students { get; set; } 
        public Teacher Teacher { get; set; }    


    }
}
