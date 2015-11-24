using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Belatrix.Logging.Tests.DataBaseOutput
{
    using Belatrix.Logging.DataBaseOutput;
    using Belatrix.Logging.Common;

    [TestClass]
    public class DataBaseLoggerTests
    {
        private Mock<IDataBaseWritter> mockOutputWriter;

        [TestInitialize]
        public void Initialize()
        {
            this.mockOutputWriter = new Mock<IDataBaseWritter>();
        }

        [TestMethod]
        public void WhenLoggingErrorShouldWriteErrorInConsole()
        {
            //Arrange            
            IJobLogger jobLogger = new DatabaseJobLogger(this.mockOutputWriter.Object);

            //Act
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            mockOutputWriter.Verify(w => w.Save(It.IsAny<Message>()), Times.Once);
        }
    }
}
