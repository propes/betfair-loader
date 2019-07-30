using System.Linq;
using app.lib.Logging;
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

        [Fact]
        public void LogDuplicate_AddsDuplicateToLog()
        {
            var sut = new Logger();

            sut.LogDuplicate("foo");

            Assert.Equal("foo", sut.Duplicates.ElementAt(0));
        }

        [Fact]
        public void Errors_ShouldReturnOnlyErrors()
        {
            var sut = new Logger();

            sut.LogError("foo");
            sut.LogError("bar");
            sut.LogDuplicate("baz");

            Assert.Equal(2, sut.Errors.Count());
        }

        [Fact]
        public void Duplicates_ShouldReturnOnlyErrors()
        {
            var sut = new Logger();

            sut.LogError("foo");
            sut.LogDuplicate("bar");
            sut.LogDuplicate("baz");

            Assert.Equal(2, sut.Duplicates.Count());
        }

        [Fact]
        public void LogRecord_IncrementsRecordCount()
        {
            var sut = new Logger();

            sut.LogRecord();
            sut.LogRecord();
            sut.LogRecord();

            Assert.Equal(3, sut.RecordCount);
        }

        [Fact]
        public void LogSuccess_IncrementsSuccessCount()
        {
            var sut = new Logger();

            sut.LogSuccess();
            sut.LogSuccess();
            sut.LogSuccess();

            Assert.Equal(3, sut.SuccessCount);
        }
    }
}