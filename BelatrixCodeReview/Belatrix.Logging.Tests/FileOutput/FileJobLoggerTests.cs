using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Belatrix.Logging.Tests
{
    using Belatrix.Logging.Common;
    using Belatrix.Logging.FileOutput;

    [TestClass]
    public class FileJobLoggerTests
    {
        private Mock<IFileWritter> mockOutputWriter;

        [TestInitialize]
        public void Initialize()
        {
            this.mockOutputWriter = new Mock<IFileWritter>();
        }

        [TestMethod]
        public void WhenLoggingErrorShouldWriteErrorInConsole()
        {
            //Arrange            
            IJobLogger jobLogger = new FileJobLogger(this.mockOutputWriter.Object);

            //Act
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            mockOutputWriter.Verify(w => w.WriteFile(It.IsAny<Message>()), Times.Once);
        }
    }
}
