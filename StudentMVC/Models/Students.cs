namespace StudentMVC.Models
{
    public class Students
    {
        public Guid Id { get; set; }   
        public string Name { get; set; }
        public int RollNO { get; set; }
        public string Class {get; set; }

        public DateTime DOB { get; set; }

        
    }
}
