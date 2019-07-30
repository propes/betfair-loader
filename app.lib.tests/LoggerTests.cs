using System.Linq;
using Xunit;

namespace app.lib.tests
{
    public class LoggerTests
    {
        [Fact]
        public void LogError_AddsErrorToLog()
        {
            var sut = new Logger();

            var errors = new [] { "foo", "bar", "baz"};

            foreach (var error in errors)
            {
                sut.LogError(error);
            }

            Assert.Equal(errors, sut.Errors);
        }
    }
}