namespace Student.Models
{
    public class CarsTable
    {
        public int Id { get; set; }
        public string ?CarName { get; set; }
        public string ?Brand { get; set; }
        public int ?Price { get; set; }
        public int ?RemainDebt { get; set; }
        //public StudentsTable? StudentsTable { get; set; }

    
        public int FK_StudentId { get; set; }
    }
}
