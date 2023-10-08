using UnityEngine;

/// <summary>
/// 
/// </summary>
public interface ILogger
{
    public void Log(string message);
}

/// <summary>
/// 
/// </summary>
public class Logger : ILogger
{
    public void Log(string message)
    {
        Debug.Log(message);
    }
}

/// <summary>
/// 
/// </summary>
public class NoLogging : ILogger
{
    public void Log(string message)
    {
        //Debug.Log("Logging Disabled in the class");
    }
}
