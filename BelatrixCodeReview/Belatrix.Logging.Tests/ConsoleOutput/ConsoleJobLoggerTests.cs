using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssert;
using Moq;

namespace Belatrix.Logging.Tests
{
    using Belatrix.Logging.ConsoleOutput;
    using Belatrix.Logging.Common;

    [TestClass]
    public class ConsoleJobLoggerTests
    {
        private Mock<IOutputWriter> mockOutputWriter;

        [TestInitialize]
        public void Initialize()
        {
            this.mockOutputWriter = new Mock<IOutputWriter>();
        }

        [TestMethod]
        public void WhenLoggingErrorShouldWriteErrorInConsole()
        { 
            //Arrange            
            IJobLogger jobLogger = new ConsoleJobLogger(this.mockOutputWriter.Object);

            //Act
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            mockOutputWriter.Verify(w => w.WriteLine(It.IsAny<string>()), Times.Once);
        }
    }
}
