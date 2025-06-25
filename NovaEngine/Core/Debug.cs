using System.Runtime.CompilerServices;

namespace NovaEngine {
    public static class Debug {
        public static void LogInfo(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {

            string className = Path.GetFileNameWithoutExtension(filePath);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] {className}.{memberName} (Line {lineNumber}): {message}");
            Console.ResetColor();
        }


        public static void LogWarn(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {

            string className = Path.GetFileNameWithoutExtension(filePath);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[Warn] {className}.{memberName} (Line {lineNumber}): {message}");
            Console.ResetColor();
        }


        public static void LogError(string message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int lineNumber = 0) {

            string className = Path.GetFileNameWithoutExtension(filePath);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[Error] {className}.{memberName} (Line {lineNumber}): {message}");
            Console.ResetColor();
        }
    }
}
