using Spectre.Console;

namespace GitSystem.Helper;

// (c) Moonlight Panel - https://github.com/Moonlight-Panel/Installer/blob/v2/LICENSE
using System.Diagnostics;

public class BashHelper
{

    // Add Custom Command Execute by tnsjesper
    public static Task<Process> CustomExecute(string command)
    {
        Process cmd = new Process();
        cmd.StartInfo.FileName = "/bin/bash";
        cmd.StartInfo.RedirectStandardInput = true;
        cmd.StartInfo.RedirectStandardOutput = true;
        cmd.StartInfo.CreateNoWindow = true;
        cmd.StartInfo.UseShellExecute = false;
        cmd.Start();
        AnsiConsole.Markup("[gray bold]:desktop_computer: Command Output: [/]\n");
        cmd.StandardInput.WriteLine(command);
        cmd.StandardInput.Flush();
        cmd.StandardInput.Close();
        cmd.WaitForExit();

        Console.WriteLine("\n");
        AnsiConsole.Markup("[gray bold]:desktop_computer: Log Output: [/]\n");
        AnsiConsole.Markup($" [gray]{cmd.StandardOutput.ReadToEnd()}[/]\n\n");
        return Task.FromResult(cmd);
    }
    
    
    public static async Task<string> CheckInstalled(string command)
    {
        Process cmd = new Process();
        cmd.StartInfo.FileName = "/bin/bash";
        cmd.StartInfo.Arguments = $"{command}";
        cmd.StartInfo.RedirectStandardInput = true;
        cmd.StartInfo.RedirectStandardOutput = true;
        cmd.StartInfo.CreateNoWindow = true;
        cmd.StartInfo.UseShellExecute = false;
        cmd.Start();

        var output = await cmd.StandardOutput.ReadToEndAsync();
        await cmd.WaitForExitAsync();
        
        return output.Trim();
    }


}