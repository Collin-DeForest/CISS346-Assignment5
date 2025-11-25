using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SMP_Library
{
    public sealed class ExceptionLogger
	{
		private static StringBuilder m_stringBuilder = new StringBuilder();

		public static bool LogExeption(Exception ex)
		{     
            try
            {
                ExceptionLoggerHelper.LogMessage(GetExceptionDetail(ex));
            }
            catch
            {
                return false;
            }

            return true;
		}

        public static string GetExceptionDetail(Exception ex)
        {
            m_stringBuilder.Clear();

            m_stringBuilder.Append("Date/Time: " + DateTime.Now + Environment.NewLine);

            m_stringBuilder.Append("Assembly: " + Assembly.GetEntryAssembly().FullName + Environment.NewLine);
            m_stringBuilder.Append("Operating System: " + Environment.OSVersion + Environment.NewLine);
            m_stringBuilder.Append("Working Set: " + Environment.WorkingSet + Environment.NewLine);

            m_stringBuilder.Append("Message: ");
            m_stringBuilder.Append(ex.Message);
            m_stringBuilder.Append(Environment.NewLine);

            m_stringBuilder.Append("Source: ");
            m_stringBuilder.Append(ex.Source);
            m_stringBuilder.Append(Environment.NewLine);

            if (ex.InnerException != null)
            {
                m_stringBuilder.Append("InnerException Message: ");
                m_stringBuilder.Append(ex.InnerException.Message);
                m_stringBuilder.Append(Environment.NewLine);

                m_stringBuilder.Append("InnerException Source: ");
                m_stringBuilder.Append(ex.InnerException.Source);
                m_stringBuilder.Append(Environment.NewLine);

                m_stringBuilder.Append("InnerException Stack Trace: " + Environment.NewLine);
                m_stringBuilder.Append(ex.InnerException.StackTrace);
                m_stringBuilder.Append(Environment.NewLine);
            }

            m_stringBuilder.Append("Exception Stack Trace: " + Environment.NewLine);
            m_stringBuilder.Append(ex.StackTrace);
            m_stringBuilder.Append(Environment.NewLine);

            return m_stringBuilder.ToString();
        }
	}

    internal static class ExceptionLoggerHelper
    {
        //Public Static Fields
        public static bool LOG = true;
        private static string m_LogFilename;
        private static object m_SyncLock = new object();

        public static string LogFilename
        {
            get { return ExceptionLoggerHelper.m_LogFilename; }
        }

        static ExceptionLoggerHelper()
        {
            string filename = "ExceptionLogger_" 
                    + DateTime.Now.Year + "_"
                    + DateTime.Now.Month + "_"
                    + DateTime.Now.Day + "_"
                    + DateTime.Now.Hour + "_"
                    + DateTime.Now.Minute + "_"
                    + DateTime.Now.Second + "_"
                    + ".txt";

            CreateLogFile(filename);
        }

        private static void CreateLogFile(string filename)
        {
            try
            {
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "LogFilesDirectory");

                if (Directory.Exists(logFilePath) == false)
                {
                    Directory.CreateDirectory(logFilePath);

                    Thread.Sleep(5000);
                }
                
                m_LogFilename = Path.Combine(logFilePath, filename);

                FileStream filestream = File.Create(m_LogFilename);

                filestream.Close();
            }
            catch
            {
                throw;
            }
        }

        public static void LogMessage(String message)
        {
            if (LOG)
            {
                lock (m_SyncLock)
                {
                    StreamWriter writer = null;

                    try
                    {
                        writer = new StreamWriter(m_LogFilename, true);

                        writer.WriteLine(message);

                        writer.Close();
                    }
                    catch
                    {
                        if (writer != null) writer.Close();

                        throw;
                    }
                }
            }
        }

        public static void ClearLog()
        {
            lock (m_SyncLock)
            {
                FileStream filestream = null;

                try
                {
                    File.Delete(m_LogFilename);

                    filestream = File.Create(m_LogFilename);

                    filestream.Close();
                }
                catch
                {
                    if (filestream != null) filestream.Close();

                    throw;
                }
            }
        }
    }
}
