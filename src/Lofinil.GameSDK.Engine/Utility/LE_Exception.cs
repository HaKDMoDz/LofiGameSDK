using System;

namespace Lofinil.GameSDK.Engine
{
    public class LE_Exception
    {
        public enum ExceptionType
        {
            NullPath,
        }

        public static void ConsoleWarn(ExceptionType type)
        {
            Console.WriteLine(type.ToString());
        }
    }
}