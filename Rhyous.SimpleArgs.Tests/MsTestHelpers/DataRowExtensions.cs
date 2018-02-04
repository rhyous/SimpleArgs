using System.Data;

namespace Rhyous.SimpleArgs.Tests.MsTestHelpers
{
    public static class DataRowExtensions
    {
        public static TestData Data(this DataRow row)
        {
            return new TestData(row[0].ToString(), row[1].ToString());
        }
    }
}
