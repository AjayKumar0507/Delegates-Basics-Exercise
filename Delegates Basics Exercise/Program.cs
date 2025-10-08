namespace Delegates_Basics_Exercise
{
    class Program
    {
        public delegate void LogDel(string text);

        public static void Main(string[] args)
        {
            // LogDel logScreenDel = new LogDel(LogTextToScreen);

            // logScreenDel("Hello world!");
            // logScreenDel.Invoke("Welcome to C#");

            // var name = Console.ReadLine();
            // logScreenDel(name);

            // LogDel logTextDel = new LogDel(LogTextToFile);
            // logTextDel(name);

            Log log = new Log();
            LogDel logScreenDel = new LogDel(log.LogTextToScreen);
            LogText(logScreenDel, "Hello World");

            LogDel logFileDel = new LogDel(log.LogTextToFile);
            LogText(logFileDel, "Hello World");

            LogDel multiLogDel = logScreenDel + logFileDel;
            LogText(multiLogDel, "Hello World");
        }

        // When passing parameters, the scope of parameters should be greater than scope of the method
        // so that the parameters can be used in the function block.
        public static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }

        public class Log
        {
            public void LogTextToScreen(string text)
            {
                Console.WriteLine($"{DateTime.Now}: {text}");
            }

            public void LogTextToFile(string text)
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), true))
                {
                    sw.WriteLine($"{DateTime.Now}: {text}");
                }
            }

        }

        static void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        static void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }



    }
}