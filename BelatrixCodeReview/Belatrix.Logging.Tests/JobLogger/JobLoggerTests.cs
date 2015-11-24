using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Xml.Linq;

namespace Belatrix.Logging.Tests.Facade
{
    using Belatrix.Logging.Facade;
    using Belatrix.Logging.Factory;
    using Belatrix.Logging.ConsoleOutput;
    using Belatrix.Logging.Builder;
    using Belatrix.Logging.Common;
    using Belatrix.Logging.DataBaseOutput;
    using Belatrix.Logging.FileOutput;
    using Belatrix.Logging.Exceptions;

    [TestClass]
    public class LoggingFacadeTests
    {
        private IMessageFactory messageFactory;
        private Mock<IJobLoggerFactory> mockJobLoggerFactory;
        private Mock<IOutputWriter> mockOutputWriter;
        private Mock<IDataBaseWritter> mockDatabaseWriter;
        private Mock<IFileWritter> mockFileWriter;

        [TestInitialize]
        public void Initialize()
        {            
            this.mockJobLoggerFactory = new Mock<IJobLoggerFactory>();
            this.mockOutputWriter = new Mock<IOutputWriter>();
            this.mockDatabaseWriter = new Mock<IDataBaseWritter>();
            this.mockFileWriter = new Mock<IFileWritter>();

            this.mockJobLoggerFactory.Setup(jl => jl.Create(It.IsAny<Enum.EnumJobLoggerType>()))
                                     .Returns((Enum.EnumJobLoggerType type) => 
                                     {
                                         IJobLogger jobLogger = (IJobLogger)null;

                                         switch (type)
                                         {
                                             case Enum.EnumJobLoggerType.CONSOLE:
                                                 {
                                                     jobLogger = new ConsoleJobLogger(mockOutputWriter.Object);
                                                     break;
                                                 }
                                             case Enum.EnumJobLoggerType.DATABASE:
                                                 {
                                                     jobLogger = new DatabaseJobLogger(mockDatabaseWriter.Object);
                                                     break;
                                                 }
                                             default:
                                                 {
                                                     jobLogger = new FileJobLogger(mockFileWriter.Object);
                                                     break;
                                                 }
                                         }

                                         return jobLogger;
                                     });

            this.messageFactory = new MessageFactory();
        }

        [TestMethod]
        public void WhenConsoleLogIsEnabledShouldContainActiveConsoleJobLogger()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableConsoleLog()
                                            .EnableErrorMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.ActiveLoggers[0].Should().NotBeNull();
            jobLogger.ActiveLoggers.Count.Should().NotBe(0);
            jobLogger.ActiveLoggers[0].Should().BeOfType<ConsoleJobLogger>();
        }

        [TestMethod]
        public void WhenConsoleLogIsEnabledShouldContainActiveDatabaseJobLogger()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableDatabaseLog()
                                            .EnableErrorMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.ActiveLoggers[0].Should().NotBeNull();
            jobLogger.ActiveLoggers.Count.Should().NotBe(0);
            jobLogger.ActiveLoggers[0].Should().BeOfType<DatabaseJobLogger>();
        }

        [TestMethod]
        public void WhenConsoleLogIsEnabledShouldContainActiveFileJobLogger()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableFileLog()
                                            .EnableErrorMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.ActiveLoggers[0].Should().NotBeNull();
            jobLogger.ActiveLoggers.Count.Should().NotBe(0);
            jobLogger.ActiveLoggers[0].Should().BeOfType<FileJobLogger>();
        }

        [TestMethod]
        public void WhenJobLoggerHasEnabledAllLoggerTypesShouldContainThreeInstancesOfIJobLogger()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableFileLog()
                                            .EnableConsoleLog()
                                            .EnableDatabaseLog()
                                            .EnableErrorMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.ActiveLoggers[0].Should().NotBeNull();
            jobLogger.ActiveLoggers.Count.Should().Be(3);
        }

        [TestMethod]
        public void WhenJobLoggerEnableErrorsLogErrorPropertyShouldBeTrue()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableFileLog()
                                            .EnableErrorMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.LogErrors.Should().BeTrue();
            jobLogger.LogWarnings.Should().BeFalse();
            jobLogger.LogInfo.Should().BeFalse();
        }

        [TestMethod]
        public void WhenJobLoggerEnableWarningsLogErrorPropertyShouldBeTrue()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableFileLog()
                                            .EnableWarningMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.LogErrors.Should().BeFalse();
            jobLogger.LogWarnings.Should().BeTrue();
            jobLogger.LogInfo.Should().BeFalse();
        }

        [TestMethod]
        public void WhenJobLoggerEnableInfoLogErrorPropertyShouldBeTrue()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableFileLog()
                                            .EnableInfoMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.LogErrors.Should().BeFalse();
            jobLogger.LogWarnings.Should().BeFalse();
            jobLogger.LogInfo.Should().BeTrue();
        }

        [TestMethod]
        public void WhenJobLoggerEnableAllLogErrorPropertyShouldBeTrue()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableFileLog()
                                            .EnableInfoMessage()
                                            .EnableWarningMessage()
                                            .EnableErrorMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            jobLogger.LogErrors.Should().BeTrue();
            jobLogger.LogWarnings.Should().BeTrue();
            jobLogger.LogInfo.Should().BeTrue();
        }

        [TestMethod]
        public void WhenJobLoggerDisabledAllMessagesTypeShouldThrowAnException()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableConsoleLog()
                                            .Build();

            //Act            
            Action action = () => 
            {
                jobLogger.LogMessage(MessageFixture.CreateError()); 
            };

            //Assert
            action.ShouldThrow<JobLoggerConfigurationException>();
        }

        [TestMethod]
        public void WhenJobLoggerEnableAnyMessageLogTypeShouldNotThrowAnException()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableConsoleLog()
                                            .EnableInfoMessage()
                                            .Build();

            //Act            
            Action action = () =>
            {
                jobLogger.LogMessage(MessageFixture.CreateError());
            };

            //Assert
            action.ShouldNotThrow<JobLoggerConfigurationException>();
        }

        [TestMethod]
        public void WhenMessageTextIsEmptyShouldThrowAnException()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableConsoleLog()
                                            .EnableInfoMessage()
                                            .Build();

            //Act            
            Action action = () =>
            {
                jobLogger.LogMessage(MessageFixture.CreateNullMessageText());
            };

            //Assert
            action.ShouldThrow<JobLoggerConfigurationException>();
        }

        [TestMethod]
        public void WhenEnableAllLoggersShouldCallThem()
        {
            //Arrange
            var jobLoggerBuilder = new JobLoggerBuilder(new JobLogger(), mockJobLoggerFactory.Object);
            var jobLogger = jobLoggerBuilder.EnableConsoleLog()
                                            .EnableDatabaseLog()
                                            .EnableFileLog()
                                            .EnableInfoMessage()
                                            .EnableErrorMessage()
                                            .EnableWarningMessage()
                                            .Build();

            //Act            
            jobLogger.LogMessage(MessageFixture.CreateError());

            //Assert
            mockDatabaseWriter.Verify(w => w.Save(It.IsAny<Message>()), Times.Once);
            mockFileWriter.Verify(w => w.WriteFile(It.IsAny<Message>()), Times.Once);
            mockOutputWriter.Verify(w => w.WriteLine(It.IsAny<Message>()), Times.Once);
        }
    }
}
