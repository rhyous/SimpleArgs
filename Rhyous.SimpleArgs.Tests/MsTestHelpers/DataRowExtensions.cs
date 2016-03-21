using System.Data;

namespace SimpleArgs.Tests.MsTestHelpers
{
    public static class DataRowExtensions
    {
        public static TestData Data(this DataRow row)
        {
            return new TestData(row[0].ToString(), row[1].ToString());
        }
    }
}
