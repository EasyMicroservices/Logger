using EasyMicroservices.Logger.Providers;
using EasyMicroservices.ServiceContracts;
using Logary;
using System;
using System.Linq;

namespace EasyMicroservices.Logger.Logary.Providers;
/// <summary>
/// 
/// </summary>
public class LogaryProvider : BaseProvider
{
    readonly global::Logary.Logger _logger;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="logger"></param>
    public LogaryProvider(global::Logary.Logger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 
    /// </summary>
    public LogaryProvider()
    {
        _logger = global::Logary.Log.Create("Default");
    }

    MessageContract Log(object[] args, LogLevel logLevel)
    {
        var extracted = Extract(args);
        AddNotExistItems(extracted);
        var message = MessageModule.Event(logLevel, $"{extracted.Messages.First()}");
        if (extracted.HasExceptions)
            MessageModule.Event(logLevel, $"{extracted.Exceptions.First()}");

        _logger.logWithAck(true,logLevel, Microsoft.FSharp.Core.FuncConvert.FromFunc<LogLevel, Message>((x)=> message));
        return (MessageContract)true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Verbose(params object[] args)
    {
        return Log(args, LogLevel.Verbose);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Debug(params object[] args)
    {
        return Log(args, LogLevel.Debug);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Information(params object[] args)
    {
        return Log(args, LogLevel.Info);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Warning(params object[] args)
    {
        return Log(args, LogLevel.Warn);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Error(params object[] args)
    {
        return Log(args, LogLevel.Error);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Fatal(params object[] args)
    {
        return Log(args, LogLevel.Fatal);
    }
}