using EasyMicroservices.Logger.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EasyMicroservices.Logger.Tests
{
    public abstract class BaseProviderAsyncTest
    {
        ILoggerProviderAsync _logger;
        public BaseProviderAsyncTest(ILoggerProviderAsync logger)
        {
            _logger = logger;
        }

        [Theory]
        [InlineData("Hello world Debug")]
        [InlineData("Hello world Debug 2")]
        public async Task MessageDebug(string message)
        {
            await _logger.DebugAsync(message);
            await _logger.DebugAsync(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Verbose")]
        [InlineData("Hello world Verbose 2")]
        public async Task MessageVerbose(string message)
        {
            await _logger.VerboseAsync(message);
            await _logger.VerboseAsync(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Information")]
        [InlineData("Hello world Information 2")]
        public async Task MessageInformation(string message)
        {
            await _logger.InformationAsync(message);
            await _logger.InformationAsync(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Warning")]
        [InlineData("Hello world Warning 2")]
        public async Task MessageWarning(string message)
        {
            await _logger.WarningAsync(message);
            await _logger.WarningAsync(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Error")]
        [InlineData("Hello world Error 2")]
        public async Task MessageError(string message)
        {
            await _logger.ErrorAsync(message);
            await _logger.ErrorAsync(message, new Exception($"exception {message}"));
        }

        [Theory]
        [InlineData("Hello world Fatal")]
        [InlineData("Hello world Fatal 2")]
        public async Task MessageFatal(string message)
        {
            await _logger.FatalAsync(message);
            await _logger.FatalAsync(message, new Exception($"exception {message}"));
        }
    }
}
