namespace ZrakForum.DataAccess.Utilities
{
    public sealed class DapperConnectionString
    {
        public DapperConnectionString(string value) => Value = value;

        public string Value { get; }
    }
}
