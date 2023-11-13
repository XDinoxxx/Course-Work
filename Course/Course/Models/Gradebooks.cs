namespace Course.Models
{
    public class Gradebooks
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int lesson_id { get; set; }
        public int grade { get;set; }
        public int homework_grade { get; set; }
    }
}
