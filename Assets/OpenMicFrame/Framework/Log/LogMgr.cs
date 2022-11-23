// /**
//  * File Name: LogMgr.cs
//  * Create By: soybeanmilk
//  * Create Time: 2022/11/23 13:21
//  * Descrption:
//  *
//  */

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Framework.Log
{
    public class LogMgr : ILog
    {
        private readonly Dictionary<string, bool> logTag = new Dictionary<string, bool>();

        public bool logEnabled { get; set; }

        public void Init()
        {
        }

        public void Destroy()
        {
            logTag.Clear();
        }

        public void SetTag(string tag, bool enable)
        {
            logTag[tag] = enable;
        }

        public void Log(ELogType type, string tag, string log)
        {
            if (!CheckLog(type, tag))
                return;

            var sbLog = new StringBuilder();
            sbLog.AppendFormat("[{0}] {1}", tag, log);
            log = sbLog.ToString();

            switch (type)
            {
                case ELogType.Debug:
                    Debug.Log(log);
                    break;
                case ELogType.Warning:
                    Debug.LogWarning(log);
                    break;
                case ELogType.Error:
                    Debug.LogError(log);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public void LogF(ELogType type, string tag, string format, params object[] objs)
        {
            if (!CheckLog(type, tag))
                return;

            var sb = new StringBuilder();
            sb.AppendFormat(format, objs);

            Log(type, tag, sb.ToString());
        }

        private bool CheckLog(ELogType type, string tag)
        {
            if (!logEnabled && type != ELogType.Error)
                return false;

            return logTag.TryGetValue(tag, out var show) && show;
        }
    }
}