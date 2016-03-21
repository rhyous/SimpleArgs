namespace SimpleArgs.Tests.MsTestHelpers
{
    public class TestData
    {
        public TestData()
        {
        }

        public TestData(string value, string message)
        {
            Value = value;
            Message = message;
        }

        public string Value { get; set; }
        public string Message { get; set; }
    }
}
