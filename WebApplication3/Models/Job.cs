namespace WebApplication3.Models
{
    public class Job
    {
        public int JobID { get; set; }
        public int UserID { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryID { get; set; }
        public string Location { get; set; }
        public decimal Salary { get; set; }
        public DateTime PublishDate { get; set; }

    }
}
