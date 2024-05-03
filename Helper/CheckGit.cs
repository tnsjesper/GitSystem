using System.Diagnostics;
using Spectre.Console;

namespace GitSystem.Helper;

public class CheckGit
{
    public static async Task<Process> CheckGitInstallation(bool Check)
    {
        Process process = new Process();
        AnsiConsole.Markup($"[white]:check_mark_button: Check git and gh installation[/]\n");


        if (await BashHelper.ExecuteCommand("which gh") != "")
            AnsiConsole.Markup("[gray] Github Cli is Installed![/]\n");
        else
        {
            AnsiConsole.Markup("[red] Github Cli is not installed![/]\n");
            AnsiConsole.Markup("[gray] Install Github Cli[/]\n");

            await BashHelper.ExecuteCommand("sudo apt update && sudo apt install gh");
        }

        if (await BashHelper.ExecuteCommand("which git") != "")
            AnsiConsole.Markup("[gray] Git is Installed![/]\n");
        else
        {
            AnsiConsole.Markup("[red] Git is not installed![/]\n");
            AnsiConsole.Markup("[gray] Install Git[/]\n\n");

            await BashHelper.ExecuteCommand("sudo apt install git-all");
        }

        return process;

    }
}