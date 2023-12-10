using EasyMicroservices.Logger.Providers;
using EasyMicroservices.ServiceContracts;
using Sentry;
using System;
using System.Linq;

namespace EasyMicroservices.Logger.Sentry.Providers;
/// <summary>
/// 
/// </summary>
public class SentryProvider : BaseProvider
{
    /// <summary>
    /// 
    /// </summary>
    public SentryProvider()
    {
        //using (SentrySdk.Init(o => {
        //    // Tells which project in Sentry to send events to:
        //    o.Dsn = "https://<key>@sentry.io/<project>";
        //    // When configuring for the first time, to see what the SDK is doing:
        //    o.Debug = true;
        //    // Set TracesSampleRate to 1.0 to capture 100% of transactions for performance monitoring.
        //    // We recommend adjusting this value in production.
        //    o.TracesSampleRate = 1.0;
        //}))
        //{

        //    // App code goes here - Disposing will flush events out
        //}
    }

    MessageContract InternalLog(object[] args, SentryLevel sentryLevel, Func<string, SentryLevel, SentryId> action)
    {
        var extracted = Extract(args);
        AddNotExistItems(extracted);
        action($"{extracted.Messages.First()}", sentryLevel);
        if (extracted.HasExceptions)
            action($"{extracted.Exceptions.First()}", sentryLevel);
        return (MessageContract)true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Verbose(params object[] args)
    {
        return InternalLog(args, SentryLevel.Debug, SentrySdk.CaptureMessage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Debug(params object[] args)
    {
        return InternalLog(args, SentryLevel.Debug, SentrySdk.CaptureMessage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Information(params object[] args)
    {
        return InternalLog(args, SentryLevel.Info, SentrySdk.CaptureMessage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Warning(params object[] args)
    {
        return InternalLog(args, SentryLevel.Warning, SentrySdk.CaptureMessage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Error(params object[] args)
    {
        return InternalLog(args, SentryLevel.Error, SentrySdk.CaptureMessage);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Fatal(params object[] args)
    {
        return InternalLog(args, SentryLevel.Fatal, SentrySdk.CaptureMessage);
    }
}