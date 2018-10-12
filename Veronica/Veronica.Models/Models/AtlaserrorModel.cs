namespace Veronica.Models
{
    public class AtlaserrorModel
    {
        public int? UniqueIDError { get; set; }
        public string DescShort { get; set; }
        public string Description { get; set; }
        public string SysBeginDateTime { get; set; }
        public string MachineName { get; set; }
        public string StackTrace { get; set; }
        public string AppName { get; set; }
        public int? TransactionID { get; set; }
        public int? BucketID { get; set; }
    }

    public class AtlaserrorCount
    {
        public string ExecutionStatus { get; set; }
        public int ? RowCount { get; set; }

    }
}
