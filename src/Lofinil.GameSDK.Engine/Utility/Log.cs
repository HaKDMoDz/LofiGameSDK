using System;
using System.Collections.Generic;
using System.IO;

namespace Lofinil.GameSDK.Engine
{
    internal static class Log
    {
        #region Constants

        public const String LogFilePath = "GameLog.txt";

        #endregion Constants

        // 用户临时消息堆栈 - 用于游戏编辑器消息堆栈输出
        private static List<String> userLogStack = new List<string>();

        private static StreamWriter streamWriter = null;

        public static void WriteLog(String userLog, String devLog)
        {
            if (devLog == "")
                devLog = userLog;
            Console.Write(devLog);
            userLogStack.Add(userLog);
            streamWriter.Write(devLog);
        }

        public static void ShowUserLog()
        {
            //if(SceneEditor.Instance.Initialed)
            //{
            //    SceneEditor.Instance.ShowInfo(userLogStack);
            //}
            userLogStack.Clear();
        }

        public static void InitialLog()
        {
            streamWriter = new StreamWriter(LogFilePath, false);
        }

        public static void ClostLog()
        {
            // 全局异常处理函数中应当调用该函数，保证未处理异常能够被记录
        }

        public static void ConsoleLog(String log)
        {
            Console.WriteLine(log);
        }
    }
}