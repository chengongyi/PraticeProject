﻿using System;
using System.IO;

namespace PostSharpExample
{
    class LoggingHelper
    {
        private const String _errLogFilePath = @"log.txt";

        public static void Writelog(String message)
        {
            StreamWriter sw = new StreamWriter(_errLogFilePath, true);
            String logContent = String.Format("[{0}]{1}", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"), message);
            sw.WriteLine(logContent);
            sw.Flush();
            sw.Close();
        }
    }
}