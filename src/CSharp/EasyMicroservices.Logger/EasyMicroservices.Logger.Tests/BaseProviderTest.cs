using EasyMicroservices.Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace EasyMicroservices.Logger.Tests
{
    public abstract class BaseProviderTest
    {
        ILoggerProvider _logger;
        public BaseProviderTest(ILoggerProvider logger)
        {
            _logger = logger;
        }

        [Theory]
        [InlineData("Hello world Debug")]
        [InlineData("Hello world Debug 2")]
        public void MessageDebug(string message)
        {
            _logger.Debug(message);
            _logger.Debug(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Verbose")]
        [InlineData("Hello world Verbose 2")]
        public void MessageVerbose(string message)
        {
            _logger.Verbose(message);
            _logger.Verbose(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Information")]
        [InlineData("Hello world Information 2")]
        public void MessageInformation(string message)
        {
            _logger.Information(message);
            _logger.Information(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Warning")]
        [InlineData("Hello world Warning 2")]
        public void MessageWarning(string message)
        {
            _logger.Warning(message);
            _logger.Warning(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Error")]
        [InlineData("Hello world Error 2")]
        public void MessageError(string message)
        {
            _logger.Error(message);
            _logger.Error(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Fatal")]
        [InlineData("Hello world Fatal 2")]
        public void MessageFatal(string message)
        {
            _logger.Fatal(message);
            _logger.Fatal(message, new Exception($"exception {message}"));
        }
    }
}
