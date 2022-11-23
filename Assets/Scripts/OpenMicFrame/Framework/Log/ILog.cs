// /**
//  * File Name: ILog.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 13:12
//  * Descrption:
//  *
//  */

namespace OpenMicFrame.Framework.Log
{
    public enum ELogType
    {
        Debug = 0,
        Warning,
        Error
    }

    public interface ILog
    {
        bool logEnabled { get; set; }

        void Init();
        void Destroy();
        void SetTag(string tag, bool enable);
        void Log(ELogType type, string tag, string log);
        void LogF(ELogType type, string tag, string format, params object[] objs);
    }
}