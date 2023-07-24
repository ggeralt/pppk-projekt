namespace SQLViewer.Model
{
    public class Column
    {
        public string Name { get; set; }
        public string DataType { get; set; }

        public override string ToString()
        {
            return $"{Name} ({DataType})";
        }
    }
}
