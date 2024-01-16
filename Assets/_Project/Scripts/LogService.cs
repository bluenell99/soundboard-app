using UnityEngine;

public class LogService : Singleton<LogService>
{
    [SerializeField] private bool _enableLogs;

    public bool EnableLogs => _enableLogs;


    /// <summary>
    /// Logs a message if "Logging" is enabled
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {
        if (_enableLogs)
        {
            Debug.Log(message);
        }
    }


}



