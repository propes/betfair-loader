﻿using System;
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

            Assert.Equal(5, _fixture.CountRecords());
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

        [Fact]
        public void LoadFile_GivenLineIsAlreadyInDatabase_DoNotLoadLine()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/valid.txt");
            sut.LoadFile("TestData/dupes.txt");

            Assert.Equal(7, _fixture.CountRecords());
        }

        [Fact]
        public void LoadFile_GivenLineIsAlreadyInDatabase_LogDuplicate()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/valid.txt");
            sut.LoadFile("TestData/dupes.txt");

            Assert.Equal(3, _fixture.Logger.DuplicateCount);
        }

        [Fact]
        public void LoadFile_LogsRecords()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/valid.txt");

            Assert.Equal(5, _fixture.Logger.RecordCount);
        }

        [Fact]
        public void LoadFile_LogsSuccessfulRecords()
        {
            var sut = _fixture.CreateSut();

            sut.LoadFile("TestData/invalid.txt");

            Assert.Equal(2, _fixture.Logger.SuccessCount);
        }

        public void Dispose()
        {
            _fixture.Dispose();
        }
    }
}