using System;
using Xunit;

namespace app.lib.tests
{
    public class MongoDataLoaderTests : IDisposable
    {
        private readonly MongoDataLoaderFixture _fixture = new MongoDataLoaderFixture();

        [Fact]
        public void LoadFile_GivenInvalidPath_ThrowsException()
        {
            var sut = _fixture.CreateSut();

            Assert.Throws<ArgumentException>(() => sut.LoadFile("foo"));
        }

        [Fact]
        public void LoadFile_GivenValidData_LoadsFile()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/valid.txt");

            Assert.Equal(215, _fixture.CountRecords());
        }

        [Fact]
        public void LoadFile_GivenInvalidData_LogsError()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/invalid.txt");

            Assert.Equal(3, _fixture.Logger.ErrorCount);
        }

        [Fact]
        public void LoadFile_GivenInvalidData_LoadsValidLines()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/invalid.txt");

            Assert.Equal(2, _fixture.CountRecords());
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}