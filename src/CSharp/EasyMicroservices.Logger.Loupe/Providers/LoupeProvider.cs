using EasyMicroservices.Logger.Providers;
using EasyMicroservices.ServiceContracts;
using Gibraltar.Agent;
using System;
using System.Linq;

namespace EasyMicroservices.Logger.Loupe.Providers;
/// <summary>
/// 
/// </summary>
public class LoupeProvider : BaseProvider
{
    /// <summary>
    /// 
    /// </summary>
    public LoupeProvider()
    {

    }

    MessageContract InternalLog(object[] args, Action<string, object[]> action)
    {
        var extracted = Extract(args);
        AddNotExistItems(extracted);
        action($"{extracted.Messages.First()}", null);
        if (extracted.HasExceptions)
            action($"{extracted.Exceptions.First()}", null);
        return (MessageContract)true;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Verbose(params object[] args)
    {
        return InternalLog(args, Log.TraceVerbose);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Debug(params object[] args)
    {
        return InternalLog(args, Log.TraceVerbose);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Information(params object[] args)
    {
        return InternalLog(args, Log.TraceInformation);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override MessageContract Warning(params object[] args)
    {
        return InternalLog(args, Log.TraceWarning);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Error(params object[] args)
    {
        return InternalLog(args, Log.TraceError);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public override MessageContract Fatal(params object[] args)
    {
        return InternalLog(args, Log.TraceCritical);
    }
}