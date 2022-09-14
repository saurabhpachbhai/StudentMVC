namespace StudentMVC.Models
{
	public class EditStudent
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int RollNO { get; set; }
        public string Class { get; set; }
        public DateTime DOB { get; set; }
    }
}
