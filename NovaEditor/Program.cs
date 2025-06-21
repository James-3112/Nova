using NovaEngine;
using System.Reflection;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Running Game in Editor");

        string scriptPath = @"Game/Scripts/Player.cs";
        string[] lines = File.ReadAllLines(scriptPath);

        Console.WriteLine(string.Join("\n", lines));
    }
}
