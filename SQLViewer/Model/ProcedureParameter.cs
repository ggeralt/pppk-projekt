namespace SQLViewer.Model
{
    public class ProcedureParameter
    {
        public string Name { get; set; }
        public string Mode { get; set; }
        public string DataType { get; set; }

        public override string ToString()
        {
            return $"{Mode} {Name} ({DataType})";
        }
    }
}
