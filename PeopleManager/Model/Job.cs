namespace PeopleManager.Model
{
    public class Job
    {
        public int IDJob { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{IDJob} | {Name}";
        }
    }
}
